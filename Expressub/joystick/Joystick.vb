Public Class Joystick
    Private SelectionMode As Integer = 1
    Public FrameStart As Integer
    'D�claration des variables 

    Dim dx As New DxVBLibA.DirectX8                     'Cr�er un objet DirectX8
    Dim di As DxVBLibA.DirectInput8                     'DirectInput8 est une classe qui repr�sente le syst�me DirectInput
    Dim diDev As DxVBLibA.DirectInputDevice8            'DirectInputDevice8 est une classe qui contient les m�thodes pour

    'acc�der aux p�riph�riques DirectInput
    Dim diDevEnum As DxVBLibA.DirectInputEnumDevices8   'DirectInputEnumDevices8 est une classe qui enum�re les

    'p�riph�riques DirectInput install�s
    Dim joyCaps As DxVBLibA.DIDEVCAPS                   'Structure contenant des informations sur le p�riph�rique
    Dim js As DxVBLibA.DIJOYSTATE                       'Structure contenant l'�tat des touches du p�riph�rique

    Dim tEnumJoy(10) As String
    Dim etatJoy As Boolean

    Private Function CreateAndEnumJoystick()

        Dim i As Integer        'Compteur i

        'Enum�re les p�riph�riques disponibles
        'DxVBLibA.CONST_DI8DEVICETYPE.DI8DEVCLASS_GAMECTRL : P�riph de controleurs de jeux
        'DxVBLibA.CONST_DIENUMDEVICESFLAGS.DIEDFL_ATTACHEDONLY : P�riph install�s et pr�ts
        diDevEnum = di.GetDIDevices(DxVBLibA.CONST_DI8DEVICETYPE.DI8DEVCLASS_GAMECTRL, DxVBLibA.CONST_DIENUMDEVICESFLAGS.DIEDFL_ATTACHEDONLY)

        For i = 1 To diDevEnum.GetCount     'Enum�re les joypads et stock le ProductName dans le tableau de joypads
            tEnumJoy(i - 1) = diDevEnum.GetItem(i).GetProductName
        Next

        If diDevEnum.GetCount > 0 Then      'Si Joypad connect�

            'Cr� une nouvelle instance d'un p�riph�rique pass� en param�tre
            diDev = di.CreateDevice(diDevEnum.GetItem(1).GetGuidInstance)

            'Sp�cifie le type de controlers  DirectInput auquel on souhaite acc�der
            diDev.SetCommonDataFormat(DxVBLibA.CONST_DICOMMONDATAFORMATS.DIFORMAT_JOYSTICK)

            'Actualise la structure joyCaps avec les infos du p�riph.
            diDev.GetCapabilities(joyCaps)

            'Acc�de au p�riph�rique
            diDev.Acquire()

            etatJoy = True      'Joypad pr�t a etre lu
            Return tEnumJoy(0)

        Else                            'Si aucun joypad connect�
            etatJoy = False       'Joypad in�xistant
            Return "Aucun Joypad pr�sent"
        End If

    End Function

    'Callback
    'Lecture du joypad en boucle avec gestion des erreurs et de la d�connexion du joypad
    Public Sub Callback()

        Dim i As Integer            'compteur i
        Dim valButtons As Integer   'valeur des boutons a afficher

        On Error GoTo Erreur        'Gestion des erreurs

        'Actualise l'�tat du joystick.
        diDev.GetDeviceStateJoystick(js)

        ' Affiche les donn�es du joystick sur le formulaire

        valButtons = 0

        If Not Timer2.Enabled Then

            For i = 0 To joyCaps.lButtons - 1
                If js.Buttons(i) = 128 Then
                    Timer2.Enabled = True
                    valButtons = valButtons + (2 ^ i)
                End If
            Next

            Select Case valButtons

                Case 1
                    If SelectionMode = 1 Then
                        Main.AudioEditor.Stop()
                        Main.AudioEditor.Play()
                    Else
                        FrameStart = Main.AudioEditor.Position.StartSelect
                        Main.AudioEditor.Position.CurrentPosition = Main.AudioEditor.Position.EndSelect - Main.AudioEditor.Position.SecToSamples(500)
                        Main.AudioEditor.Play()
                    End If
                    
                Case 2
                    If SelectionMode = 1 Then
                        Main.Label1.Text = "End Time"
                        SelectionMode = 2
                    Else
                        Main.Label1.Text = "Start Time"
                        SelectionMode = 1
                    End If
                Case 4

                Case 8
                    Main.AudioEditor.Stop()
                Case 270

            End Select

        End If

        If js.POV(0) <> -1 Then
            Select Case js.POV(0) / 100

                Case 0

                Case 90
                    If SelectionMode = 1 Then
                        AudioStartSelect(Main.AudioEditor.Position.StartSelect + 10000)
                        Main.AudioEditor.Position.CurrentPosition = Main.AudioEditor.Position.StartSelect
                        FrameStart = Main.AudioEditor.Position.StartSelect
                        Main.AudioEditor.Play()
                    Else
                        AudioEndSelect(Main.AudioEditor.Position.EndSelect + 10000)
                        Main.AudioEditor.Play()
                    End If
                Case 180

                Case 270
                    If SelectionMode = 1 Then
                        AudioStartSelect(Main.AudioEditor.Position.StartSelect - 10000)
                        Main.AudioEditor.Position.CurrentPosition = Main.AudioEditor.Position.StartSelect
                        FrameStart = Main.AudioEditor.Position.StartSelect
                        Main.AudioEditor.Play()
                    Else
                        AudioEndSelect(Main.AudioEditor.Position.EndSelect - 10000)
                        Main.AudioEditor.Play()
                    End If

            End Select
        End If

        If js.x <> 32767 Then
            If js.x < 32767 Then
                If SelectionMode = 1 Then
                    AudioStartSelect(Main.AudioEditor.Position.StartSelect - ((32767 - js.x) \ 3))
                    Main.AudioEditor.Position.CurrentPosition = Main.AudioEditor.Position.StartSelect
                    FrameStart = Main.AudioEditor.Position.StartSelect
                    Main.AudioEditor.Play()
                Else
                    AudioEndSelect(Main.AudioEditor.Position.EndSelect - ((32767 - js.x) \ 3))
                    Main.AudioEditor.Play()
                End If

            Else
                If SelectionMode = 1 Then
                    AudioStartSelect(Main.AudioEditor.Position.StartSelect - ((32767 - js.x) \ 3))
                    Main.AudioEditor.Position.CurrentPosition = Main.AudioEditor.Position.StartSelect
                    FrameStart = Main.AudioEditor.Position.StartSelect
                    Main.AudioEditor.Play()
                Else
                    AudioEndSelect(Main.AudioEditor.Position.EndSelect - ((32767 - js.x) \ 3))
                    Main.AudioEditor.Play()
                End If
            End If
        End If

        'Gestion des erreurs
        'Si Joystick d�connet�
Erreur: If Err.Number = DxVBLibA.CONST_DINPUTERR.DIERR_INPUTLOST Then
            etatJoy = False
            diDev.Unacquire()
            MessageBox.Show("JoyPad d�connect�", "Erreur Joypad", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Err.Number <> 0 Then 'Autre erreurs ....
            MessageBox.Show("Erreur Joypad inconnue", "Erreur Joypad", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Public Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If etatJoy = True Then  'Si joypad connect� 
            Callback()
        Else                    'sinon
            di = dx.DirectInputCreate
            CreateAndEnumJoystick() 'Cr�e et �num�re les joypads
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Dispose()
    End Sub
End Class