# SoReFetch

Tool to fetch firmware &amp; data from Microsoft Lumia Software Repository Server

## Help

```
Software Repository (SoRe) Fetch Utility
Copyright 2021 (c) Gustave Monce

This software uses code from the following open source projects released under the MIT license:

WPinternals - Copyright (c) 2018, Rene Lergner - wpinternals.net - @Heathcliff74xda

Please see 3RDPARTY.txt for more information

SoReFetch 1.0.0
Copyright (C) 2021 SoReFetch

ERROR(S):
  Required option 't, product-type' is missing.

  -c, --product-code         Product Code.

  -t, --product-type         Required. Product Type.

  -o, --operator-code        Operator Code.

  -r, --revision             Revision (useful for getting older package versions).

  -f, --firmware-revision    Phone Firmware Revision (useful only for changing what Test package you get for
                             ENOSW/MMOS).

  --help                     Display this help screen.

  --version                  Display version information.

```

Example:

```SoReFetch -c 059X4D5 -f 01078.00053.16236.35035 -o ATT-US -t RM-1104```
