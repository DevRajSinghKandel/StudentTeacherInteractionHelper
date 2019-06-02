Imports Windows.Storage
Imports Windows.UI.Input.Inking
Imports Windows.UI.Input.Inking.Analysis
Imports Windows.UI.Xaml.Media.Imaging
' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page
    Dim namin As List(Of mostexpensivepayload
        )
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        'Inking capabilities are added.
        namin = New List(Of mostexpensivepayload
            )

        Appl.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse Or Windows.UI.Core.CoreInputDeviceTypes.Pen
    End Sub

    Private Sub AddQuestion_Click(sender As Object, e As RoutedEventArgs) Handles AddQuestion.Click
        QuestionList.Items.Add(Questioner.Text)
    End Sub

    Private Async Sub Analysis_Click(sender As Object, e As RoutedEventArgs) Handles Analysis.Click
        'Getting the analysis done
        'COding the ink analysis of handwriting

        Dim u As InkStrokeContainer = Appl.InkPresenter.StrokeContainer
        Dim vamones As New InkRecognizerContainer()
        Dim fash As IReadOnlyList(Of InkRecognitionResult
            ) = Await vamones.RecognizeAsync(u, InkRecognitionTarget.All)
        Dim intermediary As String = ""
        For Each ram As InkRecognitionResult In fash
            Dim rsef As InkRecognitionResult = ram
            Dim fanomn As IReadOnlyList(Of String) = rsef.GetTextCandidates()
            intermediary = intermediary + fanomn(0) + " "
        Next
        Tappu.Text = intermediary
    End Sub

    Private Async Sub Currenot_Click(sender As Object, e As RoutedEventArgs) Handles Currenot.Click
        'Saving the bitmap image
        Dim qr As Windows.Storage.Streams.IRandomAccessStream

        Dim kanos As StorageFile
        Dim nff = Await Windows.Storage.ApplicationData.Current.LocalFolder.TryGetItemAsync("Hipro.jpeg")
        If nff IsNot Nothing Then

            'If nothing is there

            kanos = Await Windows.Storage.StorageFile.GetFileFromPathAsync(nff.Path)
        Else
            kanos = Await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("Hipro.jpeg")
            Dim nf As FileProperties.ImageProperties = Await kanos.Properties.GetImagePropertiesAsync

        End If

        qr = Await kanos.OpenAsync(FileAccessMode.ReadWrite, StorageOpenOptions.AllowReadersAndWriters)

        Await Appl.InkPresenter.StrokeContainer.SaveAsync(qr)



        Dim vare = Await kanos.OpenAsync(FileAccessMode.Read)
        Dim napolean As New BitmapImage
        napolean.SetSource(vare)
        'Loading the bitmap
        'Finally saving both text and bitmap




        Dim vna As New mostexpensivepayload

        vna.question = QuestionList.SelectedItem

        vna.hamper = napolean

        namin.Add(vna)



    End Sub

    Private Sub Mergere_Click(sender As Object, e As RoutedEventArgs) Handles Mergere.Click
        'Trying to merge the result
        'Trying to show the data
        'Taru is the new of the listiview

        Taru.DataContext = namin

    End Sub

    Private Sub Clearer_Click(sender As Object, e As RoutedEventArgs) Handles Clearer.Click
        'Try to clear all data
        namin.Clear()

        namin = New List(Of mostexpensivepayload
            )
        Taru.DataContext = namin


    End Sub
End Class


Class mostexpensivepayload
    Public Property question As String
    Public Property hamper As BitmapImage
End Class
