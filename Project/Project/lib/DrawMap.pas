library DrawMap;

uses graphABC;
///Выводим нарисованную карту
function PaintMap(s: string; a:array of integer;c1: array of integer; c2: array of integer; c3: array of integer; x: array of integer; y: array of integer):string;
begin
  //s - имя карты на ввод
  //p - карта
  var p:=new picture(s);
  window.Width :=p.width;
  window.Height:=p.height;
  p.draw(0,0);
  for var i:=0 to c1.Length-1 do
    floodfill(x[i],y[i], ARGB(a[i],c1[i],c2[i],c3[i]));
  var NameFile:='Map stats.png';
  Window.Save(NameFile);
  result:=NameFile;
end;

///Выдает длину легенды
function LengthOfLegend(c1:array of integer):integer;
begin
  result:=880;//Установил, как наибольшую длину легенды
  if c1.Length<11 then
    if c1.Length<=5 then
      result:=400//Меньше делать размер смысла нет
    else
      result:=400 + (c1.Length-5)*80;
end;

///Обрабатываю числа (1 000 000 >>> 1 000к)
function NumbersOfLegend(a:real):string;
begin
  var b:=0;
  var l:='';
  if a<100000 then
    l:=a.ToString
  else
  begin
    b:=Trunc(a) div 1000;
    l:=b.ToString+'K';
  end;
  if b>100000 then
  begin
    b:=b div 1000;
    l:=b.ToString+'M';
  end;
  result:=l;
end;

///Рисует легенду и передает её имя
function PaintLegend(al:array of integer; c1: array of integer; c2: array of integer; c3: array of integer; a: array of real):picture;
begin
  var w:=LengthOfLegend(c1);//длина легенды
  var h:=35;                //высота легеды
  var N := c1.Length;       //кол-во цветов
  var MyScale:= w div N;    //единица длины нашей шкалы
  Result := new Picture(w, 45);//будущая картинка
  font.Size := 9;
  //Прямоугольники
  for var i := 0 to N - 1 do
  begin
    Brush.Color := ARGB(al[i],c1[i],c2[i],c3[i]);
    result.Fillrectangle(i * MyScale, 0, (i + 1) * MyScale, (h div 3) * 2);
  end;
  Brush.Color:=color.White;
  
  //Числа
  var t:=NumbersOfLegend(a[0]); //Число для легенды снизу
  result.TextOut(0, (h div 3) * 2 + 5, t);//(h div 3) * 2 + 5. Прибавляю 5, чтоб было чуть ниже легенды
  for var i := 1 to N - 1 do
  begin
    t:=NumbersOfLegend(a[i]); //Число для легенды снизу
    result.TextOut(i * MyScale - (TextWidth(t) div 2), (h div 3) * 2 + 5, t);//Также прибавляю 5
    //- (TextWidth(t) div 2) Чтобы число под легендой было по центру деление
  end;
  t:=NumbersOfLegend(a[n-1]);
  result.TextOut(MyScale*N - (TextWidth(t)), (h div 3) * 2 + 5, t);
end;

///Сохраняет картинку в отдельном файле
function LegendOfFile(al:array of integer; c1: array of integer; c2: array of integer; c3: array of integer; a: array of real):string;
begin
  var p:=PaintLegend(al,c1,c2,c3,a);
  window.Width :=p.width;
  window.Height:=p.height;
  p.draw(0,0);
  //----------
  var w:=LengthOfLegend(c1);//длина легенды
  var h:=35;                //высота легеды
  var N := c1.Length;       //кол-во цветов
  var MyScale:= w div N;    //единица длины нашей шкалы
  font.Size := 9;
  //Линии
  //горизонтальные
  for var i := 0 to N do
  begin
    Line(i*MyScale, 0,i*MyScale, 22);
  end;
  //вертикальные
  Line(0,0,MyScale*N,0);
  Line(0,22,MyScale*N,22);
  //-----------
  var NameFile:='LegendOfFile.png';
  Window.Save(NameFile);
  result:=NameFile;
end;
end.