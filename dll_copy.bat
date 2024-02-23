echo 1.%1
echo 2.%2
echo 3.%3

@REM コピー元
set filePath1=%1%2%3.dll
echo 01.%filePath1%
@REM コピー先
cd ../
set filePath2=%cd%\%3.dll
echo 02.%filePath2%
@REM コピー実行
copy /y %filePath1% %filePath2%