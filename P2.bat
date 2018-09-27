IF NOT EXIST %1 goto end
if -"%2"==-"" goto end
if -"%1"==-"" goto end
if NOT EXIST %2\nul goto end
copy %1 %2\12
goto qw
:end
ECHO копирование не возможно
:qw