<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GameLogic = New System.Windows.Forms.Timer(Me.components)
        Me.EnemyLogic = New System.Windows.Forms.Timer(Me.components)
        Me.Path1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.EnemyBase = New System.Windows.Forms.PictureBox()
        Me.Path2 = New System.Windows.Forms.PictureBox()
        Me.Path3 = New System.Windows.Forms.PictureBox()
        Me.PicBase = New System.Windows.Forms.PictureBox()
        Me.LblLives = New System.Windows.Forms.Label()
        Me.LblCoins = New System.Windows.Forms.Label()
        Me.LblWave = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.QuitButton = New System.Windows.Forms.Button()
        Me.RetryButton = New System.Windows.Forms.Button()
        Me.LblGameOver = New System.Windows.Forms.Label()
        Me.WaveCompletionUI = New System.Windows.Forms.Timer(Me.components)
        Me.LblWaveCompleted = New System.Windows.Forms.Label()
        Me.TurretPanel = New System.Windows.Forms.PictureBox()
        Me.TowerBuy1 = New System.Windows.Forms.PictureBox()
        Me.NextWaveButton = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.TowerIndicator = New System.Windows.Forms.PictureBox()
        Me.TowerIndicatorUI = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Path1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnemyBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Path2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Path3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TurretPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TowerBuy1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TowerIndicator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GameLogic
        '
        '
        'EnemyLogic
        '
        '
        'Path1
        '
        Me.Path1.BackColor = System.Drawing.Color.SandyBrown
        Me.Path1.Location = New System.Drawing.Point(-3, 236)
        Me.Path1.Name = "Path1"
        Me.Path1.Size = New System.Drawing.Size(476, 104)
        Me.Path1.TabIndex = 0
        Me.Path1.TabStop = False
        Me.Path1.Tag = "Invalid Tower Spawn"
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.SaddleBrown
        Me.PictureBox5.Location = New System.Drawing.Point(8, 79)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(89, 25)
        Me.PictureBox5.TabIndex = 4
        Me.PictureBox5.TabStop = False
        '
        'EnemyBase
        '
        Me.EnemyBase.BackColor = System.Drawing.Color.Red
        Me.EnemyBase.Location = New System.Drawing.Point(-3, 236)
        Me.EnemyBase.Name = "EnemyBase"
        Me.EnemyBase.Size = New System.Drawing.Size(18, 104)
        Me.EnemyBase.TabIndex = 5
        Me.EnemyBase.TabStop = False
        '
        'Path2
        '
        Me.Path2.BackColor = System.Drawing.Color.SandyBrown
        Me.Path2.Location = New System.Drawing.Point(369, 84)
        Me.Path2.Name = "Path2"
        Me.Path2.Size = New System.Drawing.Size(104, 256)
        Me.Path2.TabIndex = 7
        Me.Path2.TabStop = False
        '
        'Path3
        '
        Me.Path3.BackColor = System.Drawing.Color.SandyBrown
        Me.Path3.Location = New System.Drawing.Point(392, 84)
        Me.Path3.Name = "Path3"
        Me.Path3.Size = New System.Drawing.Size(500, 104)
        Me.Path3.TabIndex = 8
        Me.Path3.TabStop = False
        '
        'PicBase
        '
        Me.PicBase.BackColor = System.Drawing.Color.Cyan
        Me.PicBase.Location = New System.Drawing.Point(868, 84)
        Me.PicBase.Name = "PicBase"
        Me.PicBase.Size = New System.Drawing.Size(24, 104)
        Me.PicBase.TabIndex = 9
        Me.PicBase.TabStop = False
        '
        'LblLives
        '
        Me.LblLives.BackColor = System.Drawing.Color.SaddleBrown
        Me.LblLives.Font = New System.Drawing.Font("Agency FB", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLives.Location = New System.Drawing.Point(8, 23)
        Me.LblLives.Name = "LblLives"
        Me.LblLives.Size = New System.Drawing.Size(82, 23)
        Me.LblLives.TabIndex = 10
        Me.LblLives.Text = "LIVES 0"
        '
        'LblCoins
        '
        Me.LblCoins.BackColor = System.Drawing.Color.SaddleBrown
        Me.LblCoins.Font = New System.Drawing.Font("Agency FB", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCoins.Location = New System.Drawing.Point(96, 23)
        Me.LblCoins.Name = "LblCoins"
        Me.LblCoins.Size = New System.Drawing.Size(82, 23)
        Me.LblCoins.TabIndex = 11
        Me.LblCoins.Text = "COINS 0"
        '
        'LblWave
        '
        Me.LblWave.BackColor = System.Drawing.Color.SaddleBrown
        Me.LblWave.Font = New System.Drawing.Font("Agency FB", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWave.Location = New System.Drawing.Point(8, 79)
        Me.LblWave.Name = "LblWave"
        Me.LblWave.Size = New System.Drawing.Size(82, 25)
        Me.LblWave.TabIndex = 12
        Me.LblWave.Text = "WAVE 0"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.SaddleBrown
        Me.PictureBox1.Location = New System.Drawing.Point(8, 23)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(170, 25)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'StartButton
        '
        Me.StartButton.BackColor = System.Drawing.Color.SaddleBrown
        Me.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StartButton.Font = New System.Drawing.Font("Agency FB", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartButton.Location = New System.Drawing.Point(332, 79)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(179, 90)
        Me.StartButton.TabIndex = 14
        Me.StartButton.Text = "START"
        Me.StartButton.UseVisualStyleBackColor = False
        '
        'QuitButton
        '
        Me.QuitButton.BackColor = System.Drawing.Color.SaddleBrown
        Me.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.QuitButton.Font = New System.Drawing.Font("Agency FB", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuitButton.Location = New System.Drawing.Point(332, 224)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(179, 90)
        Me.QuitButton.TabIndex = 15
        Me.QuitButton.Text = "QUIT"
        Me.QuitButton.UseVisualStyleBackColor = False
        '
        'RetryButton
        '
        Me.RetryButton.BackColor = System.Drawing.Color.SaddleBrown
        Me.RetryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RetryButton.Font = New System.Drawing.Font("Agency FB", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RetryButton.Location = New System.Drawing.Point(332, 224)
        Me.RetryButton.Name = "RetryButton"
        Me.RetryButton.Size = New System.Drawing.Size(179, 90)
        Me.RetryButton.TabIndex = 16
        Me.RetryButton.Text = "RETRY"
        Me.RetryButton.UseVisualStyleBackColor = False
        Me.RetryButton.Visible = False
        '
        'LblGameOver
        '
        Me.LblGameOver.AutoSize = True
        Me.LblGameOver.BackColor = System.Drawing.Color.SaddleBrown
        Me.LblGameOver.Font = New System.Drawing.Font("Agency FB", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGameOver.Location = New System.Drawing.Point(232, 54)
        Me.LblGameOver.Name = "LblGameOver"
        Me.LblGameOver.Size = New System.Drawing.Size(389, 115)
        Me.LblGameOver.TabIndex = 17
        Me.LblGameOver.Text = "GAMEOVER"
        Me.LblGameOver.Visible = False
        '
        'WaveCompletionUI
        '
        Me.WaveCompletionUI.Interval = 2000
        '
        'LblWaveCompleted
        '
        Me.LblWaveCompleted.AutoSize = True
        Me.LblWaveCompleted.BackColor = System.Drawing.Color.SaddleBrown
        Me.LblWaveCompleted.Font = New System.Drawing.Font("Agency FB", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWaveCompleted.Location = New System.Drawing.Point(147, 106)
        Me.LblWaveCompleted.Name = "LblWaveCompleted"
        Me.LblWaveCompleted.Size = New System.Drawing.Size(599, 115)
        Me.LblWaveCompleted.TabIndex = 18
        Me.LblWaveCompleted.Text = "WAVECOMPLETED"
        Me.LblWaveCompleted.Visible = False
        '
        'TurretPanel
        '
        Me.TurretPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TurretPanel.Location = New System.Drawing.Point(493, 342)
        Me.TurretPanel.Name = "TurretPanel"
        Me.TurretPanel.Size = New System.Drawing.Size(364, 57)
        Me.TurretPanel.TabIndex = 19
        Me.TurretPanel.TabStop = False
        Me.TurretPanel.Visible = False
        '
        'TowerBuy1
        '
        Me.TowerBuy1.BackColor = System.Drawing.Color.CadetBlue
        Me.TowerBuy1.Location = New System.Drawing.Point(560, 352)
        Me.TowerBuy1.Name = "TowerBuy1"
        Me.TowerBuy1.Size = New System.Drawing.Size(41, 36)
        Me.TowerBuy1.TabIndex = 20
        Me.TowerBuy1.TabStop = False
        Me.TowerBuy1.Visible = False
        '
        'NextWaveButton
        '
        Me.NextWaveButton.BackColor = System.Drawing.Color.SaddleBrown
        Me.NextWaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NextWaveButton.Font = New System.Drawing.Font("Agency FB", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NextWaveButton.Location = New System.Drawing.Point(15, 198)
        Me.NextWaveButton.Name = "NextWaveButton"
        Me.NextWaveButton.Size = New System.Drawing.Size(95, 32)
        Me.NextWaveButton.TabIndex = 21
        Me.NextWaveButton.Text = "NEXTWAVE"
        Me.NextWaveButton.UseVisualStyleBackColor = False
        Me.NextWaveButton.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(469, 320)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(423, 95)
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(-3, -2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(201, 121)
        Me.PictureBox3.TabIndex = 23
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Location = New System.Drawing.Point(868, -2)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 417)
        Me.PictureBox4.TabIndex = 24
        Me.PictureBox4.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Location = New System.Drawing.Point(197, -2)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(675, 14)
        Me.PictureBox6.TabIndex = 25
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Location = New System.Drawing.Point(-3, -2)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(12, 417)
        Me.PictureBox7.TabIndex = 26
        Me.PictureBox7.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Location = New System.Drawing.Point(-3, 399)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(479, 12)
        Me.PictureBox8.TabIndex = 27
        Me.PictureBox8.TabStop = False
        '
        'PictureBox11
        '
        Me.PictureBox11.Location = New System.Drawing.Point(868, 184)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(19, 156)
        Me.PictureBox11.TabIndex = 30
        Me.PictureBox11.TabStop = False
        '
        'TowerIndicator
        '
        Me.TowerIndicator.BackColor = System.Drawing.Color.CadetBlue
        Me.TowerIndicator.Location = New System.Drawing.Point(820, 281)
        Me.TowerIndicator.Name = "TowerIndicator"
        Me.TowerIndicator.Size = New System.Drawing.Size(37, 33)
        Me.TowerIndicator.TabIndex = 35
        Me.TowerIndicator.TabStop = False
        Me.TowerIndicator.Visible = False
        '
        'TowerIndicatorUI
        '
        Me.TowerIndicatorUI.Interval = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.ForestGreen
        Me.ClientSize = New System.Drawing.Size(884, 411)
        Me.Controls.Add(Me.TowerIndicator)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.NextWaveButton)
        Me.Controls.Add(Me.TowerBuy1)
        Me.Controls.Add(Me.LblWaveCompleted)
        Me.Controls.Add(Me.LblGameOver)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.TurretPanel)
        Me.Controls.Add(Me.RetryButton)
        Me.Controls.Add(Me.LblWave)
        Me.Controls.Add(Me.LblCoins)
        Me.Controls.Add(Me.LblLives)
        Me.Controls.Add(Me.PicBase)
        Me.Controls.Add(Me.EnemyBase)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Path1)
        Me.Controls.Add(Me.Path2)
        Me.Controls.Add(Me.Path3)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox11)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Path1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnemyBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Path2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Path3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TurretPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TowerBuy1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TowerIndicator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GameLogic As Timer
    Friend WithEvents EnemyLogic As Timer
    Friend WithEvents Path1 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents EnemyBase As PictureBox
    Friend WithEvents Path2 As PictureBox
    Friend WithEvents Path3 As PictureBox
    Friend WithEvents PicBase As PictureBox
    Friend WithEvents LblLives As Label
    Friend WithEvents LblCoins As Label
    Friend WithEvents LblWave As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents StartButton As Button
    Friend WithEvents QuitButton As Button
    Friend WithEvents RetryButton As Button
    Friend WithEvents LblGameOver As Label
    Friend WithEvents WaveCompletionUI As Timer
    Friend WithEvents LblWaveCompleted As Label
    Friend WithEvents TurretPanel As PictureBox
    Friend WithEvents TowerBuy1 As PictureBox
    Friend WithEvents NextWaveButton As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents TowerIndicator As PictureBox
    Friend WithEvents TowerIndicatorUI As Timer
End Class
