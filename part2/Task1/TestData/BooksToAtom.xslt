<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:lib="urn:mentoring.advanced.xml.onlineLibrary" 
                xmlns:ext="urn:mentoring.advanced.xml.onlineLibrary.ext"
                version="1.0" exclude-result-prefixes="lib">
  <xsl:output method="xml" indent="yes" />

  <xsl:param name="currentDate" select="ext:GetCurrenDate('yyyy-MM-ddTHH:mm:ssZ', true)"/>

  <xsl:template match="/lib:catalog">
    <feed xmlns="http://www.w3.org/2005/Atom">
      <title>New books</title>
      <updated>
        <xsl:value-of select="$currentDate"/>
      </updated>
      <id>http://mylib.kz/feed</id>

      <xsl:apply-templates select="lib:book" />
    </feed>
  </xsl:template>

  <xsl:template match="lib:book">
    <entry xmlns="http://www.w3.org/2005/Atom">
      <id>
        <xsl:value-of select="concat('http://mylib.kz/books/', @id)"/>
      </id>
      <title>
        <xsl:value-of select="lib:title"/>
      </title>
      <updated>
        <xsl:value-of select="ext:convertStringDateTimeByFormat(lib:registration_date, 'yyyy-MM-ddTHH:mm:ssZ', true)"/>
      </updated>
      
      <xsl:if test="lib:isbn and lib:genre/text() = 'Computer'">
        <link>
          <xsl:attribute name="href">
            <xsl:value-of select="concat('http://my.safaribooksonline.com/', lib:isbn/text(), '/')" />
          </xsl:attribute>
        </link>
      </xsl:if>

      <author>
        <name>
          <xsl:value-of select="lib:author"/>
        </name>
      </author>

      <genre>
        <name>
          <xsl:value-of select="lib:genre"/>
        </name>
      </genre>

      <content>
        <xsl:value-of select="lib:description"/>
      </content>
    </entry>
  </xsl:template>

</xsl:stylesheet>
