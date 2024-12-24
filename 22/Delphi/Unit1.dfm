object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 466
  ClientWidth = 711
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'Segoe UI'
  Font.Style = []
  TextHeight = 15
  object esecret: TEdit
    Left = 8
    Top = 16
    Width = 121
    Height = 23
    TabOrder = 0
    Text = '123'
  end
  object lResults: TListBox
    Left = 8
    Top = 56
    Width = 305
    Height = 402
    ItemHeight = 15
    TabOrder = 1
  end
  object btnGo: TButton
    Left = 135
    Top = 15
    Width = 75
    Height = 25
    Caption = 'Go'
    TabOrder = 2
    OnClick = btnGoClick
  end
end
