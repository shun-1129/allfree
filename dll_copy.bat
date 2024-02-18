@REM コピー元
set filePath1=%2bin\%1\net6.0\%3.dll
@REM コピー先
cd ../
set filePath2=%cd%\%3.dll
@REM コピー実行
copy /y %filePath1% %filePath2%