unit umain;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics, system.Generics.Collections,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    CheckBox1: TCheckBox;
    CheckBox2: TCheckBox;
    test: TMemo;
    data: TMemo;
    Label1: TLabel;
    Label2: TLabel;
    lResult1: TLabel;
    lResult2: TLabel;
    ckTest: TCheckBox;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
    procedure part1;
    procedure part2;
    function stones(stone : int64; num : integer) : cardinal;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

{ TForm1 }

procedure TForm1.Button1Click(Sender: TObject);
begin
  if checkbox1.Checked then
    part1;
  if checkbox2.Checked then
    part2;
end;

procedure TForm1.part1;
var
  lStones : tList<int64>;
  sData : string;
  s : string;
  total : int64;
  stone : int64;
begin
    if ckTest.Checked then
      sData := test.Text
    else
      sData := data.Text;
    lStones := tlist<int64>.Create;
    for s in tArray<string>(sData.Split([' '],TStringSplitOptions.ExcludeEmpty)) do
    begin
        lStones.Add(strtoint(trim(s)));
    end;
    total := 0;
    for Stone in lStones do
      begin
        total := total + stones(stone,25);
        lResult1.caption := inttostr(total);
        Application.ProcessMessages;
      end;

end;

procedure TForm1.part2;
var
  lStones : tList<int64>;
  sData : string;
  s : string;
  total : int64;
  stone : int64;
begin
    if ckTest.Checked then
      sData := test.Text
    else
      sData := data.Text;
    lStones := tlist<int64>.Create;
    for s in tArray<string>(sData.Split([' '],TStringSplitOptions.ExcludeEmpty)) do
    begin
        lStones.Add(strtoint(trim(s)));
    end;
    total := 0;
    for Stone in lStones do
      begin
        total := total + stones(stone,75);
        lResult2.caption := inttostr(total);
        Application.ProcessMessages;
      end;


end;

function TForm1.stones(stone: int64; num: integer): cardinal;
var
  cont : boolean;
  sStone : String;
  stone1, stone2 : string;
begin
  cont := true;
  if num = 0 then begin
   result := 1;
   cont := false;
  end;

  if cont then
  begin
    if stone = 0 then
    begin
      result := stones(1, num -1);
      cont := false;
    end;
  end;
  if cont then
  begin
    sStone := inttostr(stone);
    if (sStone.Length > 1) then
    if (sStone.Length mod 2) = 0 then
    begin
       stone1 := sStone.Substring(0,round((sStone.Length / 2)));
       stone2 := sStone.Substring(round(sStone.Length / 2));
       result := stones(strtoint(stone1),num -1) + stones(strtoint(stone2), num -1);
       cont := false;
    end;
  end;
  if cont then
    result := stones(stone * 2024, num -1);


end;

end.
