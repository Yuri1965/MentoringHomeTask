echo off
set arg1=..\TestData\books_invalid_record.xml
set arg2=..\TestData\books.xsd

..\XMLUtil.exe /checkByScheme %arg1% %arg2%

pause

