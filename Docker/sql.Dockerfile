FROM mcr.microsoft.com/mssql/server:2022-latest

ENV ACCEPT_EULA=Y

COPY ./init.sql /docker-entrypoint-initdb.d/ 