FROM mcr.microsoft.com/mssql/server:2022-latest

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Kolbulle1!

COPY ./init.sql /docker-entrypoint-initdb.d/ 