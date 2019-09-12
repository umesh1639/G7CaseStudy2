echo off
cd StaticAnalyzer
msbuild StaticAnalyzer.sln
cd ..

cd StaticAnalyzer\StaticAnalyzer\bin\Debug
StaticAnalyzer.exe C:\Users\320050767\Source\Repos\G7CaseStudy13\StaticAnalyzer

IF %ERRORLEVEL% == 0 (echo Success) ELSE (echo Failure)

cd ..\..\..\..

cd StaticAnalyzer\Test\bin\Debug
Test.exe

cd ..\..\..\..
