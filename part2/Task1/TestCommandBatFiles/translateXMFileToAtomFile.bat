echo off
set arg1=..\TestData\books.xml
set arg2=..\TestData\atomBooks.xml
set arg3=..\TestData\BooksToAtom.xslt

..\XMLUtil.exe /translateToAtom %arg1% %arg2% %arg3%

pause

