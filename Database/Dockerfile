FROM timescale/timescaledb-ha:pg14-latest

ENV POSTGRES_USER postgres
ENV POSTGRES_PASSWORD password

COPY init_databases.sql /docker-entrypoint-initdb.d/10_init_databases.sql
COPY global_database.sql /docker-entrypoint-initdb.d/20_global_database.sql

VOLUME timescaledb_data:/var/lib/postgresql/data
