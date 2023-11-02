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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PicBase = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.LblLives = New System.Windows.Forms.Label()
        Me.LblGameOver = New System.Windows.Forms.Label()
        Me.LblWaves = New System.Windows.Forms.Label()
        Me.LblCoins = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.QuitButton = New System.Windows.Forms.Button()
        Me.RetryButton = New System.Windows.Forms.Button()
        Me.EnemyLogic = New System.Windows.Forms.Timer(Me.components)
        Me.GameLogic = New System.Windows.Forms.Timer(Me.components)
        Me.WaveEndingTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.SandyBrown
        Me.PictureBox1.Location = New System.Drawing.Point(0, 257)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(482, 91)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.SandyBrown
        Me.PictureBox2.Location = New System.Drawing.Point(448, 60)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(439, 91)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PicBase
        '
        Me.PicBase.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PicBase.Location = New System.Drawing.Point(870, 60)
        Me.PicBase.Name = "PicBase"
        Me.PicBase.Size = New System.Drawing.Size(17, 91)
        Me.PicBase.TabIndex = 2
        Me.PicBase.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.SaddleBrown
        Me.PictureBox6.Location = New System.Drawing.Point(12, 64)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(102, 27)
        Me.PictureBox6.TabIndex = 5
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.SandyBrown
        Me.PictureBox7.Location = New System.Drawing.Point(391, 60)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(91, 288)
        Me.PictureBox7.TabIndex = 6
        Me.PictureBox7.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PictureBox8.Location = New System.Drawing.Point(0, 257)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(17, 91)
        Me.PictureBox8.TabIndex = 7
        Me.PictureBox8.TabStop = False
        '
        'LblLives
        '
        Me.LblLives.BackColor = System.Drawing.Color.SaddleBrown
        Me.LblLives.Font = New System.Drawing.Font("Agency FB", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLives.Location = New System.Drawing.Point(12, 24)
        Me.LblLives.Name = "LblLives"
        Me.LblLives.Size = New System.Drawing.Size(63, 25)
        Me.LblLives.TabIndex = 8
        Me.LblLives.Text = "LIVES 0"
        '
        'LblGameOver
        '
        Me.LblGameOver.AutoSize = True
        Me.LblGameOver.BackColor = System.Drawing.Color.SaddleBrown
        Me.LblGameOver.Font = New System.Drawing.Font("Agency FB", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGameOver.Location = New System.Drawing.Point(240, 92)
        Me.LblGameOver.Name = "LblGameOver"
        Me.LblGameOver.Size = New System.Drawing.Size(389, 115)
        Me.LblGameOver.TabIndex = 9
        Me.LblGameOver.Text = "GAMEOVER"
        Me.LblGameOver.Visible = False
        '
        'LblWaves
        '
        Me.LblWaves.BackColor = System.Drawing.Color.SaddleBrown
        Me.LblWaves.Font = New System.Drawing.Font("Agency FB", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWaves.Location = New System.Drawing.Point(12, 64)
        Me.LblWaves.Name = "LblWaves"
        Me.LblWaves.Size = New System.Drawing.Size(73, 27)
        Me.LblWaves.TabIndex = 10
        Me.LblWaves.Text = "WAVE 0"
        '
        'LblCoins
        '
        Me.LblCoins.BackColor = System.Drawing.Color.SaddleBrown
        Me.LblCoins.Font = New System.Drawing.Font("Agency FB", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCoins.Location = New System.Drawing.Point(109, 24)
        Me.LblCoins.Name = "LblCoins"
        Me.LblCoins.Size = New System.Drawing.Size(85, 25)
        Me.LblCoins.TabIndex = 11
        Me.LblCoins.Text = "COINS 0"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.SaddleBrown
        Me.PictureBox3.Location = New System.Drawing.Point(12, 24)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(182, 25)
        Me.PictureBox3.TabIndex = 12
        Me.PictureBox3.TabStop = False
        '
        'StartButton
        '
        Me.StartButton.BackColor = System.Drawing.Color.SaddleBrown
        Me.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StartButton.Font = New System.Drawing.Font("Agency FB", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartButton.Location = New System.Drawing.Point(363, 70)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(134, 83)
        Me.StartButton.TabIndex = 13
        Me.StartButton.Text = "START"
        Me.StartButton.UseVisualStyleBackColor = False
        '
        'QuitButton
        '
        Me.QuitButton.BackColor = System.Drawing.Color.SaddleBrown
        Me.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.QuitButton.Font = New System.Drawing.Font("Agency FB", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuitButton.Location = New System.Drawing.Point(363, 221)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(134, 83)
        Me.QuitButton.TabIndex = 14
        Me.QuitButton.Text = "QUIT"
        Me.QuitButton.UseVisualStyleBackColor = False
        '
        'RetryButton
        '
        Me.RetryButton.BackColor = System.Drawing.Color.SaddleBrown
        Me.RetryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RetryButton.Font = New System.Drawing.Font("Agency FB", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RetryButton.Location = New System.Drawing.Point(363, 221)
        Me.RetryButton.Name = "RetryButton"
        Me.RetryButton.Size = New System.Drawing.Size(134, 83)
        Me.RetryButton.TabIndex = 15
        Me.RetryButton.Text = "RETRY"
        Me.RetryButton.UseVisualStyleBackColor = False
        Me.RetryButton.Visible = False
        '
        'EnemyLogic
        '
        '
        'GameLogic
        '
        '
        'WaveEndingTimer
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.ForestGreen
        Me.ClientSize = New System.Drawing.Size(884, 411)
        Me.Controls.Add(Me.LblGameOver)
        Me.Controls.Add(Me.RetryButton)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.LblCoins)
        Me.Controls.Add(Me.LblWaves)
        Me.Controls.Add(Me.LblLives)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PicBase)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Name = "Form1"
        Me.Text = "Tower Defence Game"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PicBase As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents LblLives As Label
    Friend WithEvents LblGameOver As Label
    Friend WithEvents LblWaves As Label
    Friend WithEvents LblCoins As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents StartButton As Button
    Friend WithEvents QuitButton As Button
    Friend WithEvents RetryButton As Button
    Friend WithEvents EnemyLogic As Timer
    Friend WithEvents GameLogic As Timer
    Friend WithEvents WaveEndingTimer As Timer
End Class
