
::
:: Set path to test project folder
::
SET TestFolder=TestResults
::
: Run coverage
::
:: dotnet test --filter "FullyQualifiedName~MiscellaneousTests|FullyQualifiedName~ReportTests" --collect:"XPlat Code Coverage"
dotnet test --collect:"XPlat Code Coverage"
::
: Get the path for the most recent coverage results folder
::
FOR /F "delims=|" %%I IN ('DIR "%TestFolder%\*.*" /B /O:D') DO SET NewestPath=%%I
::
: Generate HTML report for latter coverage results
::
reportgenerator -reports:%TestFolder%\%NewestPath%\coverage.cobertura.xml -targetdir:Coverage
::
: Open the browser for coverage report index.htm
::
Coverage\index.htm