unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Math;

type
  TForm1 = class(TForm)
    esecret: TEdit;
    lResults: TListBox;
    btnGo: TButton;
    procedure btnGoClick(Sender: TObject);
  private
    { Private declarations }
    function mix(secret, shift : integer): integer;
    function prune(secret : integer) : integer;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.btnGoClick(Sender: TObject);
var
  secret : integer;
begin
  secret := strtoint(esecret.Text);
  secret := mix(secret,secret * 64);
  secret := mix(secret,secret div 32);
  secret := mix(secret,secret*2048);
  lResults.Items.Add(inttostr(secret));

end;

function TForm1.mix(secret, shift: integer): integer;
begin
  result := prune(secret xor shift);
end;

function TForm1.prune(secret: integer): integer;
begin
  result := secret mod 16777216;
end;

end.
