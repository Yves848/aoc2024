object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 441
  ClientWidth = 624
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'Segoe UI'
  Font.Style = []
  TextHeight = 15
  object Label1: TLabel
    Left = 128
    Top = 16
    Width = 41
    Height = 15
    Caption = 'Result : '
  end
  object Label2: TLabel
    Left = 128
    Top = 39
    Width = 41
    Height = 15
    Caption = 'Result : '
  end
  object lResult1: TLabel
    Left = 184
    Top = 16
    Width = 41
    Height = 15
    Caption = 'lResult1'
  end
  object lResult2: TLabel
    Left = 184
    Top = 39
    Width = 41
    Height = 15
    Caption = 'lResult2'
  end
  object Button1: TButton
    Left = 8
    Top = 96
    Width = 75
    Height = 25
    Caption = 'Go'
    TabOrder = 0
    OnClick = Button1Click
  end
  object CheckBox1: TCheckBox
    Left = 8
    Top = 16
    Width = 97
    Height = 17
    Caption = 'Part1'
    TabOrder = 1
  end
  object CheckBox2: TCheckBox
    Left = 8
    Top = 39
    Width = 97
    Height = 17
    Caption = 'Part2'
    TabOrder = 2
  end
  object test: TMemo
    Left = 8
    Top = 144
    Width = 608
    Height = 89
    Lines.Strings = (
      '125 17')
    TabOrder = 3
  end
  object data: TMemo
    Left = 8
    Top = 239
    Width = 608
    Height = 89
    Lines.Strings = (
      '4 4841539 66 5279 49207 134 609568 0')
    TabOrder = 4
  end
  object ckTest: TCheckBox
    Left = 8
    Top = 73
    Width = 41
    Height = 17
    Caption = 'Test'
    Checked = True
    State = cbChecked
    TabOrder = 5
  end
end