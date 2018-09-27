IF NOT EXIST %1 goto end
if -"%2"==-"" goto end
if -"%1"==-"" goto end
if NOT EXIST %2\nul goto end
copy %0 %1
goto qw
:end
ECHO копирование не возможно
:qw