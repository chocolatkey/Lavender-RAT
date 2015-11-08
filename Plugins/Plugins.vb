''' <summary>
''' Plugin interface
''' </summary>
Public Interface IPlugin
    ''' <summary>
    ''' Plugin Name
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property Name As String
    ''' <summary>
    ''' Plugin Name (English)
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property LongName As String
    ''' <summary>
    ''' Plugin Description
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property Description As String
    ''' <summary>
    ''' Plugin Type
    ''' </summary>
    ''' <returns>True for Server, False for Client</returns>
    ReadOnly Property Type As Boolean
    ''' <summary>
    ''' Should plugin remain after server instance restart or be deleted?
    ''' </summary>
    ''' <returns>Plugin persistance</returns>
    ReadOnly Property Persistence As Boolean
    ''' <summary>
    ''' Data manipulation function of the plugin
    ''' </summary>
    ''' <param name="A">Data</param>
    ''' <param name="sock">Socket</param>
    ''' <returns>Return array of objects to be handled</returns>
    Function Func(ByVal sock As Integer, Optional ByVal A As String() = Nothing, Optional ByVal B As Byte() = Nothing) As Object()
End Interface