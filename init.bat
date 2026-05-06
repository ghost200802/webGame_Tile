@echo off
set UOMAWEB_PATH=Assets\uomaweb
set UOMAWEB_URL=git@github.com:ghost200802/uomaweb.git
set UOMAWEB_BRANCH=unity

if exist "%UOMAWEB_PATH%\.git" (
    echo uomaweb already initialized, updating remote URL...
    cd %UOMAWEB_PATH%
    git remote set-url origin %UOMAWEB_URL%
    git checkout %UOMAWEB_BRANCH%
    cd ..\..
) else (
    echo Initializing uomaweb...
    if exist "%UOMAWEB_PATH%" (
        cd %UOMAWEB_PATH%
        git init
        git remote add origin %UOMAWEB_URL%
        git fetch origin %UOMAWEB_BRANCH%
        git checkout -b %UOMAWEB_BRANCH% origin/%UOMAWEB_BRANCH%
        cd ..\..
    ) else (
        git clone -b %UOMAWEB_BRANCH% %UOMAWEB_URL% %UOMAWEB_PATH%
    )
    if %errorlevel% neq 0 (
        echo Failed to initialize uomaweb!
        pause
        exit /b 1
    )
)

echo init done.
pause
