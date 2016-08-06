<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
                              xmlns:lib="urn:mentoring.advanced.xml.onlineLibrary"
                              xmlns:ext="urn:mentoring.advanced.xml.onlineLibrary.ext">
  
  <xsl:output method="xml" indent="yes"/>
    
    <xsl:param name="currentDate" select="ext:GetCurrenDate('dd.MM.yyyy HH:mm:ss', false)"/>
    
    <xsl:template match="/lib:catalog">
      <xsl:variable name="rootNode" select="." />

      <html>
        <head>
          <title>Текущие фонды по жанрам</title>
        </head>
        <body>
          <h1>Текущие фонды по жанрам</h1>
          Отчёт сформирован: <xsl:value-of select="$currentDate"/>
          <xsl:for-each select="ext:DistinctTextNodes(lib:book/lib:genre)">
            <h2>
              Жанр "<xsl:value-of select="text()"/>"
            </h2>
            <table>
              <tr>
                <th>Автор</th>
                <th>Название</th>
                <th>Дата издания</th>
                <th>Дата регистрации</th>
              </tr>
              <xsl:for-each select="$rootNode/lib:book[lib:genre=current()]">
                <tr>
                  <td><xsl:value-of select="lib:author"/></td>
                  <td><xsl:value-of select="lib:title"/></td>
                  <td><xsl:value-of select="ext:convertStringDateTimeByFormat(lib:publish_date, 'dd.MM.yyyy HH:mm:ss', false)"/></td>
                  <td><xsl:value-of select="ext:convertStringDateTimeByFormat(lib:registration_date, 'dd.MM.yyyy HH:mm:ss', false)"/></td>
                </tr>
              </xsl:for-each>
            </table>
          </xsl:for-each>
        </body>
      </html>

    </xsl:template>
</xsl:stylesheet>
