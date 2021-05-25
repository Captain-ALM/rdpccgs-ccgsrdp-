Imports Microsoft.SmallBasic.Library
Imports System.Net
''' <summary>
''' This module provides the ability to download files and strings
''' </summary>
''' <remarks></remarks>
<SmallBasicType()>
Public Module main
    ''' <summary>
    ''' Downloads a file specified by the URL to the local file path
    ''' </summary>
    ''' <param name="fileurl">The remote URL of the file</param>
    ''' <param name="filelocal">The local target path of the file</param>
    ''' <returns>True on success, False on failure</returns>
    ''' <remarks></remarks>
    Public Function downloadfile(fileurl As Primitive, filelocal As Primitive) As Primitive
        Dim result As Boolean = False
        Using webc As New WebClient()
            Try
                webc.DownloadFile(fileurl.ToString, filelocal.ToString)
                result = True
            Catch ex As Exception
            End Try
        End Using
        Return New Primitive(result)
    End Function
    ''' <summary>
    ''' Downloads a string specified by the URL and returns it
    ''' </summary>
    ''' <param name="fileurl">The remote URL of the file</param>
    ''' <returns>The downloaded or blank string</returns>
    ''' <remarks></remarks>
    Public Function downloadstring(fileurl As Primitive) As Primitive
        Dim result As String = ""
        Using webc As New WebClient()
            Try
                result = webc.DownloadString(fileurl)
            Catch ex As Exception
                result = ""
            End Try
        End Using
        Return New Primitive(result)
    End Function
End Module
