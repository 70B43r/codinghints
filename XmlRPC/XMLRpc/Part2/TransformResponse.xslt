<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
   <xsl:output method="xml" indent="yes"/>

   <xsl:template match="/methodResponse">
      <methodResponse>
         <xsl:apply-templates select="fault/value/struct/member" />
         <xsl:apply-templates select="params/param/value/struct/member" />
      </methodResponse>
   </xsl:template>

   <xsl:template match="member">
      <xsl:text disable-output-escaping="yes" >&lt;</xsl:text>
      <xsl:value-of select="./name/text()" />
      <xsl:text disable-output-escaping="yes" >&gt;</xsl:text>
      <xsl:value-of select="./value/*/text()"/>
      <xsl:text disable-output-escaping="yes" >&lt;/</xsl:text>
      <xsl:value-of select="./name/text()" />
      <xsl:text disable-output-escaping="yes" >&gt;</xsl:text>
   </xsl:template>
</xsl:stylesheet>