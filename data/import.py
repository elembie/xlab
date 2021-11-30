import os
import time
import psycopg
import pandas as pd
from pathlib import Path
from argparse import ArgumentParser
from dataclasses import dataclass, field

@dataclass
class DbConfig:

    name: str = os.environ.get('DATABASE_NAME', None)
    port: str = os.environ.get('DATABASE_PORT', None)
    password: str = os.environ.get('DATABASE_PASSWORD', None)
    host: str = os.environ.get('DATABASE_HOST')

    def is_valid(self) -> bool:
        return all([self.name, self.port, self.password, self.host])


def main(data_path: Path):
    '''Helper method to import data once the database is up
    This would not be used in a production setting - it's a helper for this challenge
    '''

    db_config = DbConfig()

    if not db_config.is_valid():
        raise Exception(f'DB config is incomplete')

    with psycopg.connect(
        dbname=db_config.name,
        host=db_config.host,
        password=db_config.password,
        user='postgres'
    ) as con:
        with con.cursor() as cursor:

            table_query = '''
                SELECT table_name 
                FROM information_schema.tables
                WHERE table_name = 'Tags'
            '''

            tries = 0
            while cursor.execute(table_query).fetchone() is None:
                print(f'Values table does not exist - waiting for migration')
                time.sleep(2)
                tries += 1
                if tries > 30: return

            print('Cleaning database')
            cursor.execute('DELETE FROM "Tags"')
            cursor.execute('DELETE FROM "Venues"')
            cursor.execute('DELETE FROM "VenueTags"')

            print(f'Found values table - starting import')
                
            df = pd.read_csv(data_path)

            nested_tags = [ 
                venue_tags.split(',') 
                for venue_tags in df['Tags'].to_list() 
                if type(venue_tags) == str 
            ]

            tags = set([ tag for venue_tags in nested_tags for tag in venue_tags ])

            for tag in tags:
                cursor.execute('INSERT INTO "Tags" ("Name") VALUES (%s)', [tag])

            tag_ids = { 
                row[1]: row[0] 
                for row in cursor.execute('SELECT * from "Tags"').fetchall() 
            }

            column_names = ','.join([ f'"{c}"' for c in df.columns if c != 'Tags' ])
            placeholders = ','.join([ f'%s' for c in df.columns if c != 'Tags' ])

            for _, row in df.iterrows():

                venue_tags = []
                if type(row['Tags']) == str:
                    venue_tags = row['Tags'].split(',')

                row.pop('Tags')
                cursor.execute(f'INSERT INTO "Venues" ({column_names}) VALUES ({placeholders})', [ c for c in row ] )
                vid = cursor.execute(f'SELECT "Id" FROM "Venues" WHERE "Url" = (%s)', [row['Url']]).fetchone()[0]
                for tag in venue_tags:
                    cursor.execute('INSERT INTO "VenueTags" ("TagId", "VenueId") VALUES (%s, %s)', ( tag_ids[tag], vid ))


if __name__ == '__main__':
    parser = ArgumentParser()
    parser.add_argument('data_path')
    data_path = parser.parse_args().data_path
    main(Path(data_path))