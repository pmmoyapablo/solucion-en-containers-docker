FROM mcr.microsoft.com/mssql/server:2019-latest
COPY src/Database/BlueBank.sql .
COPY src/Database/start.sh .
COPY src/Database/entrypoint.sh .
#RUN chmod +x ./start.sh
CMD /bin/bash ./entrypoint.sh