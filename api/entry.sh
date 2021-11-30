#!/bin/bash

cd /app

echo 'Polling for database'
# until mysqladmin ping --host=${MYSQL_HOST} --user=root --password=${MYSQL_ROOT_PASSWORD};
until pg_isready --dbname=${DATABASE_NAME} --host=${DATABASE_HOST} --port=${DATABASE_PORT};
do
    echo 'Server unavailable - sleeping'
    sleep 2
done


echo 'Database ready'

echo 'Perfoming database migrations'
dotnet clean
dotnet ef database update
echo 'Done.'

echo 'Starting server'
dotnet out/findabeer.api.dll

