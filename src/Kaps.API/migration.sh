#!/bin/bash
#  API src!
  echo "migration starting"
  dotnet ef migrations add $1
  dotnet ef database update
  echo "migration completed"