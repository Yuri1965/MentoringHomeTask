echo off
set arg1=..\TestData\books.xml
set arg2=..\TestData\reportBooks.html
set arg3=..\TestData\BooksToHtmlReport.xslt

..\XMLUtil.exe /translateToAtom %arg1% %arg2% %arg3%

pause

