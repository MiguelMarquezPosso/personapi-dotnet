#!/bin/bash
# Wait for SQL Server to be ready
echo "Waiting for SQL Server to start..."
sleep 30s

echo "Running database initialization script..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Arqui2025!" -d master -i /docker-entrypoint-initdb.d/init-db.sql

echo "Database initialization completed!"