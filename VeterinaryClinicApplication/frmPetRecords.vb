'------------------------------------------------------------ 
'-                File Name : frmPetRecords.vb              - 
'-                Part of Project: Assign1                  - 
'------------------------------------------------------------ 
'-                Written By: Elijah Wilson                 - 
'-                Written On: 1/14/16                       - 
'------------------------------------------------------------ 
'- File Purpose:                                            - 
'- This file contains the main application form where all   -
'- of the form events are handled as well as anything       -
'- related to the form (subs, functions) reside.            -
'------------------------------------------------------------ 
'- Program Purpose:                                         - 
'-                                                          - 
'- This program allows for persistant storage of pet records- 
'------------------------------------------------------------ 
'- Global Variable Dictionary (alphabetically):             - 
'- *None*                                                   – 
'------------------------------------------------------------ 
Imports System.IO
Imports System.Xml

Public Class frmPetRecords
    Private ageUnits As New List(Of String)(New String() {"Months", "Years"})
    Private currentPetRecordIndex As Integer = 0
    Private petRecords As New List(Of PetRecord)
    Private Const DATAFILEPATH = "pet_records.xml"
    Private Const FORMBASETITLE = "Veterinary Clinic System"

    '------------------------------------------------------------ 
    '-                Subprogram Name: frmPetRecords_Load       - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine is called when the form loads (once).    -
    '- it gets the data stored in the data file if it exists    -
    '- otherwise this file is created and initialized.          -
    '- It also sets up the age units list box with data         -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- sender – Identifies which particular control raised the  – 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub frmPetRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstAgeUnits.DataSource = ageUnits

        If File.Exists(DATAFILEPATH) Then
            petRecords = getRecordsFromDataFile()
        Else
            populateDataFile(petRecords)  ' petRecords will by an empty List
        End If

        If petRecords.Count = 0 Then
            updateFormForNewRecord()
        Else
            updateFormData()
            updateFormTitlePetCount()
        End If
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: populateDataFile         - 
    '------------------------------------------------------------ 
    '-                Written By: Your Name                     - 
    '-                Written On: The date you wrote it         - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine is called whenever the user clicks the   -
    '- quit button.  The program will prompt if the user really – 
    '- wants to quit, and if the user clicks Yes, the program   - 
    '- will terminate.  If the user click No, the program will  - 
    '- continue to run.                                         – 
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- records – a `List` of `PetRecord`s to be written to the  –
    '-     data file in XML.                                    -
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- dataFileWriter - StreamWriter for the data file          -
    '- serializer - XmlSerializer that serializes the records   -
    '------------------------------------------------------------
    Private Sub populateDataFile(records As List(Of PetRecord))
        Dim dataFileWriter As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(DATAFILEPATH, False)
        Dim serializer As New Serialization.XmlSerializer(GetType(List(Of PetRecord)))
        serializer.Serialize(dataFileWriter, records)
        dataFileWriter.Close()
    End Sub

    '------------------------------------------------------------ 
    '-                Function Name: getRecordsFromDataFile     - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Function Purpose:                                        - 
    '-                                                          - 
    '- This function is used to get the data from the data file -
    '- and then return a list of PetRecords.                    -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- None                                                     – 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- dataFileReader - StreamReader for reading data file      -
    '- records - List of PetRecords to be returned              -
    '- serializer - XmlSerializer to deserialize data from file -
    '------------------------------------------------------------ 
    '- Returns:                                                 - 
    '- List(Of PetRecord) – list of PetRecords                  - 
    '------------------------------------------------------------ 
    Private Function getRecordsFromDataFile() As List(Of PetRecord)
        Dim serializer As New Serialization.XmlSerializer(GetType(List(Of PetRecord)))
        Dim dataFileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(DATAFILEPATH)
        Dim records As List(Of PetRecord) = DirectCast(serializer.Deserialize(dataFileReader), List(Of PetRecord))

        dataFileReader.Close()
        Return records
    End Function

    '------------------------------------------------------------ 
    '-                Function Name: getPetStringForTitle       - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       -
    '------------------------------------------------------------ 
    '- Function Purpose:                                        - 
    '-                                                          - 
    '- This function returns a string for the current index     -
    '- plus one (0-based index) out of the number of pet records-
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- (None)                                                   –
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 - 
    '- String – Which pet out of how many are we currently at   - 
    '------------------------------------------------------------ 
    Private Function getPetStringForTitle() As String
        Return String.Format("Pet {0}/{1}", currentPetRecordIndex + 1, petRecords.Count)
    End Function

    '------------------------------------------------------------ 
    '-                Subprogram Name: updateFormTitlePetCount  - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       -
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine updates the Form's title based on the    -
    '- current index of the pet records                         -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- (None)                                                   – 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------ 
    Private Sub updateFormTitlePetCount()
        Me.Text = String.Format("{0} - {1}", FORMBASETITLE, getPetStringForTitle())
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: updateFormTitleAddNewPet - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       -
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine updates the Form's title when creating   -
    '- a new pet record                                         -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- (None)                                                   – 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------ 
    Private Sub updateFormTitleAddNewPet()
        Me.Text = String.Format("{0} - Adding New Pet", FORMBASETITLE)
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: btnNewRecord_Click       - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine updates the form for making a new record -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- sender – Identifies which particular control raised the  – 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------ 
    Private Sub btnNewRecord_Click(sender As Object, e As EventArgs) Handles btnNewRecord.Click
        updateFormForNewRecord()
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: resetAllFields           - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine resets all the form fields to their      -
    '- default state; blank, False...                           -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- (None)                                                   – 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------ 
    Private Sub resetAllFields()
        txtPetName.Text = ""
        txtOwnerName.Text = ""
        txtLastVisit.Text = ""
        txtAge.Text = ""
        txtSpecies.Text = ""
        chkIsNeutered.Checked = False
        lstAgeUnits.ClearSelected()
    End Sub

    '------------------------------------------------------------ 
    '-             Subprogram Name: changeAllFieldsEnabledState - 
    '------------------------------------------------------------ 
    '-             Written By: Elijah Wilson                    - 
    '-             Written On: 1/14/16                          - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine changes all form fields to the desired   -
    '- state of being Enabled or not                            -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- state - whether the fields should be Enabled or not      – 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------ 
    Private Sub changeAllFieldsEnabledState(state As Boolean)
        txtPetName.Enabled = state
        txtOwnerName.Enabled = state
        txtLastVisit.Enabled = state
        txtAge.Enabled = state
        txtSpecies.Enabled = state
        chkIsNeutered.Enabled = state
        lstAgeUnits.Enabled = state
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: lockAllFields            - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine disables all the fields on the form      - 
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- (None)                                                   – 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------ 
    Private Sub lockAllFields()
        changeAllFieldsEnabledState(False)
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: unlockAllFields          - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine enables all the fields on the form       - 
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- (None)                                                   – 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub unlockAllFields()
        changeAllFieldsEnabledState(True)
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: toggleButtonsForNewRecord- 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine toggles the visibility of all the        -
    '- buttons necessary for creating a new pet record          -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- (None)                                                   – 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub toggleButtonsForNewRecord()
        btnGoLeft.Hide()
        btnGoRight.Hide()
        btnNewRecord.Hide()

        btnSaveRecord.Show()
        btnCancelNewRecord.Show()
    End Sub

    '------------------------------------------------------------ 
    '-          Subprogram Name: toggleButtonsForExistingRecord - 
    '------------------------------------------------------------ 
    '-          Written By: Elijah Wilson                       - 
    '-          Written On: 1/14/16                             - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine toggles the visibility of all the        -
    '- buttons necessary for viewing an existing pet record     -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- (None)                                                   – 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub toggleButtonsForExistingRecord()
        btnGoLeft.Show()
        btnGoRight.Show()
        btnNewRecord.Show()

        btnSaveRecord.Hide()
        btnCancelNewRecord.Hide()
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: updateFormForNewRecord   - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine calls all the necessary subroutines to   -
    '- update the form to get it ready to create a new record   -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- (None)                                                   – 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------ 
    Private Sub updateFormForNewRecord()
        resetAllFields()
        unlockAllFields()
        updateFormTitleAddNewPet()
        toggleButtonsForNewRecord()
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: updateFormData           - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine updates the form for use with the current-
    '- pet record.                                              -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- (None)                                                   – 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- pet - a PetRecord that holds the current index record    -
    '------------------------------------------------------------
    Private Sub updateFormData()
        lockAllFields()
        Dim pet As PetRecord = petRecords.ElementAt(currentPetRecordIndex)
        updateFormFieldsFromPetRecord(pet)
    End Sub

    '------------------------------------------------------------ 
    '-          Subprogram Name: updateFormFieldsFromPetRecord  - 
    '------------------------------------------------------------ 
    '-          Written By: Elijah Wilson                       - 
    '-          Written On: 1/14/16                             - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine updates the form fields with data from   -
    '- a record                                                 -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- record - PetRecord to update the form with               – 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------ 
    Private Sub updateFormFieldsFromPetRecord(record As PetRecord)
        txtPetName.Text = record.name
        txtOwnerName.Text = record.ownerName
        txtLastVisit.Text = record.lastVisit
        txtAge.Text = record.age
        txtSpecies.Text = record.species
        chkIsNeutered.Checked = record.isNeutered
        lstAgeUnits.SelectedIndex = ageUnits.IndexOf(record.ageUnit)
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: btnSaveRecord_Click      - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine creates a new PetRecord from the form    -
    '- and adds the record to memory and persistant file        -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- sender – Identifies which particular control raised the  – 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- record - a PetRecord from the form data.                 -
    '------------------------------------------------------------ 
    Private Sub btnSaveRecord_Click(sender As Object, e As EventArgs) Handles btnSaveRecord.Click
        ' Create record in memory & then save records to file
        Dim record As PetRecord = getPetRecordFromFormFields()
        petRecords.Add(record)
        currentPetRecordIndex = petRecords.Count - 1  ' 0 based index for the List
        updateFormData()  ' show new data
        updateFormTitlePetCount()
        toggleButtonsForExistingRecord()
        populateDataFile(petRecords)
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: btnCancelNewRecord_Click - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine cancels out of creating a new pet record -
    '- unless there aren't any records, then it doesn't let you -
    '- leave.                                                   -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- sender – Identifies which particular control raised the  – 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- (None)                                                   -
    '------------------------------------------------------------ 
    Private Sub btnCancelNewRecord_Click(sender As Object, e As EventArgs) Handles btnCancelNewRecord.Click
        If petRecords.Count = 0 Then
            MessageBox.Show("There aren't any existing pet records, please create one first!")
        Else
            updateFormData()
            updateFormTitlePetCount()
            toggleButtonsForExistingRecord()
        End If
    End Sub

    '------------------------------------------------------------ 
    '-              Subprogram Name: getPetRecordFromFormFields - 
    '------------------------------------------------------------ 
    '-              Written By: Elijah Wilson                   - 
    '-              Written On: 1/14/16                         - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine creates & returns a new PetRecord based  -
    '- on the data provided in the form fields                  -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- (None)                                                   –
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- record - PetRecord to be returned with data from form    -
    '------------------------------------------------------------ 
    '- Returns:                                                 - 
    '- PetRecord - created from the Form fields                 - 
    '------------------------------------------------------------ 
    Function getPetRecordFromFormFields() As PetRecord
        Dim record = New PetRecord()
        record.name = txtPetName.Text
        record.age = txtAge.Text
        record.ownerName = txtOwnerName.Text
        record.species = txtSpecies.Text
        record.lastVisit = txtLastVisit.Text
        record.isNeutered = chkIsNeutered.Checked
        record.ageUnit = ageUnits.ElementAt(lstAgeUnits.SelectedIndex)

        Return record
    End Function

    '------------------------------------------------------------ 
    '-                Subprogram Name: btnGoLeft_Click          - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine decreases the current index and updates  -
    '- the form with the new data unless there aren't any more  -
    '- records to the 'left' in the List, which shows an error  -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- sender – Identifies which particular control raised the  – 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- newIndex - the current index minus one                   -
    '------------------------------------------------------------ 
    Private Sub btnGoLeft_Click(sender As Object, e As EventArgs) Handles btnGoLeft.Click
        Dim newIndex = currentPetRecordIndex - 1

        If newIndex < 0 Then
            MessageBox.Show("You cannot move past the first record!")
        Else
            currentPetRecordIndex = newIndex
            updateFormData()
            updateFormTitlePetCount()
        End If
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: btnGoRight_Click         - 
    '------------------------------------------------------------ 
    '-                Written By: Elijah Wilson                 - 
    '-                Written On: 1/14/16                       - 
    '------------------------------------------------------------ 
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine increases the current index and updates  -
    '- the form with the new data unless there aren't any more  -
    '- records to the 'right' in the List, which shows an error -
    '------------------------------------------------------------ 
    '- Parameter Dictionary (in parameter order):               - 
    '- sender – Identifies which particular control raised the  – 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary (alphabetically):              - 
    '- newIndex - the current index plus one                   -
    '------------------------------------------------------------
    Private Sub btnGoRight_Click(sender As Object, e As EventArgs) Handles btnGoRight.Click
        Dim newIndex = currentPetRecordIndex + 1

        If newIndex > (petRecords.Count - 1) Then
            MessageBox.Show("You cannot move past the last record!")
        Else
            currentPetRecordIndex = newIndex
            updateFormData()
            updateFormTitlePetCount()
        End If
    End Sub
End Class
