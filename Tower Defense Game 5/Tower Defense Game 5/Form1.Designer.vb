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
        CType(Me.Path1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnemyBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Path2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Path3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LblGameOver.Location = New System.Drawing.Point(232, 79)
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.ForestGreen
        Me.ClientSize = New System.Drawing.Size(884, 411)
        Me.Controls.Add(Me.LblWaveCompleted)
        Me.Controls.Add(Me.LblGameOver)
        Me.Controls.Add(Me.RetryButton)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
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
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Path1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnemyBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Path2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Path3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
