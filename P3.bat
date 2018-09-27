cls
set "args=%*"
:cycle
for /F "tokens=1* delims=;" %%i in ("%args%") do call %%~i& set args=%%j& if defined args goto cycle