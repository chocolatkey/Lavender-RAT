' Implements a comparer for ListView columns.
Public Class ListViewComparer
    Implements IComparer

    Private m_ColumnNumber As Integer
    Private m_SortOrder As SortOrder

    Public Sub New(ByVal column_number As Integer, ByVal _
        sort_order As SortOrder)
        m_ColumnNumber = column_number
        m_SortOrder = sort_order
    End Sub

    ' Compare the items in the appropriate column
    ' for objects x and y.
    Public Function Compare(ByVal x As Object, ByVal y As _
        Object) As Integer Implements _
        System.Collections.IComparer.Compare
        Dim item_x As ListViewItem = DirectCast(x,  _
            ListViewItem)
        Dim item_y As ListViewItem = DirectCast(y,  _
            ListViewItem)

        ' Get the sub-item values.
        Dim string_x As String
        If item_x.SubItems.Count <= m_ColumnNumber Then
            string_x = ""
        Else
            string_x = item_x.SubItems(m_ColumnNumber).Text
        End If

        Dim string_y As String
        If item_y.SubItems.Count <= m_ColumnNumber Then
            string_y = ""
        Else
            string_y = item_y.SubItems(m_ColumnNumber).Text
        End If

        ' Compare them.
        If m_SortOrder = SortOrder.Ascending Then
            If IsNumeric(string_x) And IsNumeric(string_y) Then ''normal
                Return Val(string_x).CompareTo(Val(string_y))
            ElseIf IsDate(string_x) And IsDate(string_y) Then
                Return DateTime.Parse(string_x).CompareTo(DateTime.Parse(string_y))
            Else
                If string_x.EndsWith("%") And string_y.EndsWith("%") Then ''percent
                    Dim charsToTrim() As Char = {"%"c}
                    Dim spaceToTrim() As Char = {" "c}
                    If IsNumeric(string_x.TrimEnd(charsToTrim).TrimEnd(spaceToTrim)) And IsNumeric(string_y.TrimEnd(charsToTrim).TrimEnd(spaceToTrim)) Then
                        Return Val(string_x.TrimEnd(" %")).CompareTo(Val(string_y.TrimEnd(" %")))
                    End If
                Else
                    If string_x.EndsWith("B") And string_y.EndsWith("B") Then ''bytesize
                        Dim ix As Double = 0
                        Dim iy As Double = 0
                        Dim sx As String = string_x.Substring(0, string_x.Length - 2)
                        Dim sy As String = string_y.Substring(0, string_y.Length - 2)
                        Dim sbx As String = string_x.Substring(0, string_x.Length - 1)
                        Dim sby As String = string_y.Substring(0, string_y.Length - 1)
                        Dim dx As Double
                        Dim dy As Double
                        Dim dbx As Double
                        Dim dby As Double
                        Double.TryParse(sx, dx)
                        Double.TryParse(sy, dy)
                        Double.TryParse(sbx, dbx)
                        Double.TryParse(sby, dby)
                        If ((IsNumeric(sx) Or IsNumeric(sbx)) And (IsNumeric(sy) Or IsNumeric(sby))) Then
                            If string_x.EndsWith("KB") Then
                                ix = dx * 1024
                            ElseIf string_x.EndsWith("MB") Then
                                ix = dx * 1024 * 1024
                            ElseIf string_x.EndsWith("GB") Then
                                ix = dx * 1024 * 1024 * 1024
                            ElseIf string_x.EndsWith("TB") Then
                                ix = dx * 1024 * 1024 * 1024 * 1024
                            ElseIf string_x.EndsWith("PB") Then
                                ix = dx * 1024 * 1024 * 1024 * 1024 * 1024
                            ElseIf string_x.EndsWith("EB") Then
                                ix = dx * 1024 * 1024 * 1024 * 1024 * 1024 * 1024
                            Else
                                ix = dbx
                            End If
                            If string_y.EndsWith("KB") Then
                                iy = dy * 1024
                            ElseIf string_y.EndsWith("MB") Then
                                iy = dy * 1024 * 1024
                            ElseIf string_y.EndsWith("GB") Then
                                iy = dy * 1024 * 1024 * 1024
                            ElseIf string_y.EndsWith("TB") Then
                                iy = dy * 1024 * 1024 * 1024 * 1024
                            ElseIf string_y.EndsWith("PB") Then
                                iy = dy * 1024 * 1024 * 1024 * 1024 * 1024
                            ElseIf string_y.EndsWith("EB") Then
                                iy = dy * 1024 * 1024 * 1024 * 1024 * 1024 * 1024
                            Else
                                iy = dby
                            End If
                            ''MsgBox(string_x & "|" & dx & "|" & dbx & "|" & ix & " x|y " & string_y & "|" & dy & "|" & dby & "|" & iy)
                            Return ix.CompareTo(iy)

                        End If
                    End If
                End If

                Return String.Compare(string_x, string_y) ''string
            End If
        Else
            If IsNumeric(string_x) And IsNumeric(string_y) Then ''normal
                Return Val(string_y).CompareTo(Val(string_x))
            ElseIf IsDate(string_x) And IsDate(string_y) _
                Then
                Return DateTime.Parse(string_y).CompareTo(DateTime.Parse(string_x))
            Else
                If string_x.EndsWith("%") And string_y.EndsWith("%") Then ''percent
                    Dim charsToTrim() As Char = {"%"c}
                    Dim spaceToTrim() As Char = {" "c}
                    If IsNumeric(string_x.TrimEnd(charsToTrim).TrimEnd(spaceToTrim)) And IsNumeric(string_y.TrimEnd(charsToTrim).TrimEnd(spaceToTrim)) Then
                        Return Val(string_y.Trim(" %")).CompareTo(Val(string_x.Trim(" %")))
                    End If
                Else
                    If string_x.EndsWith("B") And string_y.EndsWith("B") Then ''bytesize
                        Dim ix As Double
                        Dim iy As Double
                        Dim sx As String = string_x.Substring(0, string_x.Length - 2)
                        Dim sy As String = string_y.Substring(0, string_y.Length - 2)
                        Dim sbx As String = string_x.Substring(0, string_x.Length - 1)
                        Dim sby As String = string_y.Substring(0, string_y.Length - 1)
                        Dim dx As Double
                        Dim dy As Double
                        Dim dbx As Double
                        Dim dby As Double
                        Double.TryParse(sx, dx)
                        Double.TryParse(sy, dy)
                        Double.TryParse(sbx, dbx)
                        Double.TryParse(sby, dby)
                        If ((IsNumeric(sx) Or IsNumeric(sbx)) And (IsNumeric(sy) Or IsNumeric(sby))) Then
                            If string_x.EndsWith("KB") Then
                                ix = dx * 1024
                            ElseIf string_x.EndsWith("MB") Then
                                ix = dx * 1024 * 1024
                            ElseIf string_x.EndsWith("GB") Then
                                ix = dx * 1024 * 1024 * 1024
                            ElseIf string_x.EndsWith("TB") Then
                                ix = dx * 1024 * 1024 * 1024 * 1024
                            ElseIf string_x.EndsWith("PB") Then
                                ix = dx * 1024 * 1024 * 1024 * 1024 * 1024
                            ElseIf string_x.EndsWith("EB") Then
                                ix = dx * 1024 * 1024 * 1024 * 1024 * 1024 * 1024
                            Else
                                ix = dbx
                            End If
                            If string_y.EndsWith("KB") Then
                                iy = dy * 1024
                            ElseIf string_y.EndsWith("MB") Then
                                iy = dy * 1024 * 1024
                            ElseIf string_y.EndsWith("GB") Then
                                iy = dy * 1024 * 1024 * 1024
                            ElseIf string_y.EndsWith("TB") Then
                                iy = dy * 1024 * 1024 * 1024 * 1024
                            ElseIf string_y.EndsWith("PB") Then
                                iy = dy * 1024 * 1024 * 1024 * 1024 * 1024
                            ElseIf string_y.EndsWith("EB") Then
                                iy = dy * 1024 * 1024 * 1024 * 1024 * 1024 * 1024
                            Else
                                iy = dby
                            End If
                            'MsgBox(string_x & " " & ix & " x|y " & string_y & " " & iy)
                            Return iy.CompareTo(ix)
                        End If
                    End If
                End If

                Return String.Compare(string_y, string_x) ''string
            End If
        End If
    End Function
End Class