Public Class Joystick
    Private SelectionMode As Integer = 1
    Public FrameStart As Integer
    'Déclaration des variables 

    Dim dx As New DxVBLibA.DirectX8                     'Créer un objet DirectX8
    Dim di As DxVBLibA.DirectInput8                     'DirectInput8 est une classe qui représente le système DirectInput
    Dim diDev As DxVBLibA.DirectInputDevice8            'DirectInputDevice8 est une classe qui contient les méthodes pour

    'accéder aux périphériques DirectInput
    Dim diDevEnum As DxVBLibA.DirectInputEnumDevices8   'DirectInputEnumDevices8 est une classe qui enumère les

    'périphériques DirectInput installés
    Dim joyCaps As DxVBLibA.DIDEVCAPS                   'Structure contenant des informations sur le périphérique
    Dim js As DxVBLibA.DIJOYSTATE                       'Structure contenant l'état des touches du périphérique

    Dim tEnumJoy(10) As String
    Dim etatJoy As Boolean

    Private Function CreateAndEnumJoystick()

        Dim i As Integer        'Compteur i

        'Enumère les périphériques disponibles
        'DxVBLibA.CONST_DI8DEVICETYPE.DI8DEVCLASS_GAMECTRL : Périph de controleurs de jeux
        'DxVBLibA.CONST_DIENUMDEVICESFLAGS.DIEDFL_ATTACHEDONLY : Périph installés et prêts
        diDevEnum = di.GetDIDevices(DxVBLibA.CONST_DI8DEVICETYPE.DI8DEVCLASS_GAMECTRL, DxVBLibA.CONST_DIENUMDEVICESFLAGS.DIEDFL_ATTACHEDONLY)

        For i = 1 To diDevEnum.GetCount     'Enumère les joypads et stock le ProductName dans le tableau de joypads
            tEnumJoy(i - 1) = diDevEnum.GetItem(i).GetProductName
        Next

        If diDevEnum.GetCount > 0 Then      'Si Joypad connecté

            'Cré une nouvelle instance d'un périphérique passé en paramètre
            diDev = di.CreateDevice(diDevEnum.GetItem(1).GetGuidInstance)

            'Spécifie le type de controlers  DirectInput auquel on souhaite accéder
            diDev.SetCommonDataFormat(DxVBLibA.CONST_DICOMMONDATAFORMATS.DIFORMAT_JOYSTICK)

            'Actualise la structure joyCaps avec les infos du périph.
            diDev.GetCapabilities(joyCaps)

            'Accède au périphérique
            diDev.Acquire()

            etatJoy = True      'Joypad prêt a etre lu
            Return tEnumJoy(0)

        Else                            'Si aucun joypad connecté
            etatJoy = False       'Joypad inéxistant
            Return "Aucun Joypad présent"
        End If

    End Function

    'Callback
    'Lecture du joypad en boucle avec gestion des erreurs et de la déconnexion du joypad
    Public Sub Callback()

        Dim i As Integer            'compteur i
        Dim valButtons As Integer   'valeur des boutons a afficher

        On Error GoTo Erreur        'Gestion des erreurs

        'Actualise l'état du joystick.
        diDev.GetDeviceStateJoystick(js)

        ' Affiche les données du joystick sur le formulaire

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
        'Si Joystick déconneté
Erreur: If Err.Number = DxVBLibA.CONST_DINPUTERR.DIERR_INPUTLOST Then
            etatJoy = False
            diDev.Unacquire()
            MessageBox.Show("JoyPad déconnecté", "Erreur Joypad", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Err.Number <> 0 Then 'Autre erreurs ....
            MessageBox.Show("Erreur Joypad inconnue", "Erreur Joypad", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Public Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If etatJoy = True Then  'Si joypad connecté 
            Callback()
        Else                    'sinon
            di = dx.DirectInputCreate
            CreateAndEnumJoystick() 'Crée et énumère les joypads
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Dispose()
    End Sub
End Class