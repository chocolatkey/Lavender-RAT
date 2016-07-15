Imports System.Windows.Forms
Imports System.ComponentModel

Public Class ListViewEx
    Inherits ListView
    ''Public lvwColumnSorter As ListViewComparer
    ' The column currently used for sorting.
    Private m_SortingColumn As ColumnHeader
    ''Private arrowIcons As New

    Public Sub New()
        ''MyBase.New()
        ''InitializeComponent()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.DoubleBuffered = True

        ''Me.ListViewItemSorter = lvwColumnSorter
    End Sub

    <Browsable(True)> _
    Public Shadows Event ColumnClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)


    Private Sub csot(ByVal sender As System.Object, ByVal e As ColumnClickEventArgs) Handles Me.ColumnClick
        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = _
            Me.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("▲ ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text = _
                m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "▲ " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "▼ " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        Me.ListViewItemSorter = New  _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        Me.Sort()
    End Sub

End Class