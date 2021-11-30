#!/bin/bash

echo 'Polling for database'
# until mysqladmin ping --host=${MYSQL_HOST} --user=root --password=${MYSQL_ROOT_PASSWORD};
until pg_isready --dbname=${DATABASE_NAME} --host=${DATABASE_HOST} --port=${DATABASE_PORT};
do
    echo 'Server unavailable - sleeping'
    sleep 2
done

python ./import.py ./seed.csv