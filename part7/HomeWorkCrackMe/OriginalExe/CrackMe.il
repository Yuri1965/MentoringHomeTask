
//  Microsoft (R) .NET Framework IL Disassembler.  Version 3.5.30729.1




// Metadata version: v2.0.50727
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly extern System.Windows.Forms
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly extern System
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly extern System.Core
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 3:5:0:0
}
.assembly extern System.Drawing
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 2:0:0:0
}
.assembly CrackMe
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 6C 43 72 61 63 6B 4D 65 20 4F 62 66 75 73   // ..lCrackMe Obfus
                                                                                              63 61 74 65 64 20 77 69 74 68 20 44 6F 74 66 75   // cated with Dotfu
                                                                                              73 63 61 74 6F 72 20 50 72 6F 66 65 73 73 69 6F   // scator Professio
                                                                                              6E 61 6C 20 45 76 61 6C 75 61 74 69 6F 6E 2E 20   // nal Evaluation. 
                                                                                              49 6C 6C 65 67 61 6C 20 74 6F 20 75 73 65 20 6F   // Illegal to use o
                                                                                              6E 20 73 6F 66 74 77 61 72 65 20 66 6F 72 20 67   // n software for g
                                                                                              65 6E 65 72 61 6C 20 72 65 6C 65 61 73 65 2E 00   // eneral release..
                                                                                              00 ) 
  .custom instance void DotfuscatorAttribute::.ctor(string,
                                                    int32,
                                                    bool) = ( 01 00 16 31 38 36 33 39 39 3A 31 3A 31 3A 34 2E   // ...186399:1:1:4.
                                                              31 38 2E 31 2E 32 39 34 31 01 00 00 00 01 00 00 ) // 18.1.2941.......
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 07 43 72 61 63 6B 4D 65 00 00 )             // ...CrackMe..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  20 32 30 31 36 00 00 )                            //  2016..
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 38 30 30 30 34 65 35 65 2D 61 63 65 36   // ..$80004e5e-ace6
                                                                                                  2D 34 31 30 39 2D 61 39 38 61 2D 35 64 32 38 65   // -4109-a98a-5d28e
                                                                                                  61 65 34 39 62 61 31 00 00 )                      // ae49ba1..
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.mresource public CrackMe.Form1.resources
{
  // Offset: 0x00000000 Length: 0x000000B4
  // ВНИМАНИЕ: создан управляемый файл ресурсов CrackMe.Form1.resources
}
.mresource public CrackMe.Properties.Resources.resources
{
  // Offset: 0x000000B8 Length: 0x000000B4
  // ВНИМАНИЕ: создан управляемый файл ресурсов CrackMe.Properties.Resources.resources
}
.module CrackMe.exe
// MVID: {E929FEB7-F3DD-449F-99CD-83285EA760B5}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0002       // WINDOWS_GUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00590000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi sealed beforefieldinit DotfuscatorAttribute
       extends [mscorlib]System.Attribute
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.AttributeUsageAttribute::.ctor(valuetype [mscorlib]System.AttributeTargets) = ( 01 00 01 00 00 00 00 00 ) 
  .field private string a
  .field private bool b
  .field private int32 c
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string a,
                               int32 c,
                               bool b) cil managed
  {
    // Размер кода:       28 (0x1c)
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  call       instance void [mscorlib]System.Attribute::.ctor()
    IL_0007:  ldarg.1
    IL_0008:  stfld      string DotfuscatorAttribute::a
    IL_000d:  ldarg.0
    IL_000e:  ldarg.2
    IL_000f:  stfld      int32 DotfuscatorAttribute::c
    IL_0014:  ldarg.0
    IL_0015:  ldarg.3
    IL_0016:  stfld      bool DotfuscatorAttribute::b
    IL_001b:  ret
  } // end of method DotfuscatorAttribute::.ctor

  .method public hidebysig instance string 
          a() cil managed
  {
    // Размер кода:       7 (0x7)
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string DotfuscatorAttribute::a
    IL_0006:  ret
  } // end of method DotfuscatorAttribute::a

  .method public hidebysig instance bool 
          b() cil managed
  {
    // Размер кода:       7 (0x7)
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  ldfld      bool DotfuscatorAttribute::b
    IL_0006:  ret
  } // end of method DotfuscatorAttribute::b

  .method public hidebysig instance int32 
          c() cil managed
  {
    // Размер кода:       7 (0x7)
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 DotfuscatorAttribute::c
    IL_0006:  ret
  } // end of method DotfuscatorAttribute::c

  .property instance string A()
  {
    .get instance string DotfuscatorAttribute::a()
  } // end of property DotfuscatorAttribute::A
  .property instance bool B()
  {
    .get instance bool DotfuscatorAttribute::b()
  } // end of property DotfuscatorAttribute::B
  .property instance int32 C()
  {
    .get instance int32 DotfuscatorAttribute::c()
  } // end of property DotfuscatorAttribute::C
} // end of class DotfuscatorAttribute

.class public auto ansi beforefieldinit CrackMe.Form1
       extends [System.Windows.Forms]System.Windows.Forms.Form
{
  .class auto ansi sealed nested private beforefieldinit eval_a
         extends [mscorlib]System.Object
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public uint8[] a
    .field public int32[] b
    .field privatescope notserialized string eval_c$PST0400000E = uint8(0x20)
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Размер кода:       7 (0x7)
      .maxstack  1
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ret
    } // end of method eval_a::.ctor

    .method assembly hidebysig instance int32 
            eval_a(uint8 A_0,
                   int32 A_1) cil managed
    {
      // Размер кода:       132 (0x84)
      .maxstack  3
      .locals init (int32 V_0)
      IL_0000:  ldc.i4     0x1e8f
      IL_0005:  stloc      V_0
      IL_0009:  ldloca     V_0
      IL_000d:  ldind.i4
      IL_000e:  ldc.i4     0x1e8f
      IL_0013:  stloc      V_0
      IL_0017:  ldloca     V_0
      IL_001b:  ldind.i4
      IL_001c:  ceq
      IL_001e:  switch     ( 
                            IL_002f,
                            IL_0030,
                            IL_002f)
      IL_002f:  nop
      IL_0030:  ldc.i4     0x1
      IL_0035:  stloc      V_0
      IL_0039:  ldloca     V_0
      IL_003d:  ldind.i4
      IL_003e:  br.s       IL_004c

      IL_0040:  ldc.i4.0
      IL_0041:  stloc      V_0
      IL_0045:  ldloca     V_0
      IL_0049:  ldind.i4
      IL_004a:  br.s       IL_004c

      IL_004c:  brfalse.s  IL_004e

      IL_004e:  ldc.i4.0
      IL_004f:  stloc      V_0
      IL_0053:  ldloca     V_0
      IL_0057:  ldind.i4
      IL_0058:  brfalse    IL_005d

      IL_005d:  br.s       IL_006c

      IL_005f:  ldc.i4.0
      IL_0060:  stloc      V_0
      IL_0064:  ldloca     V_0
      IL_0068:  ldind.i4
      IL_0069:  pop
      IL_006a:  br.s       IL_0078

      IL_006c:  ldc.i4.0
      IL_006d:  stloc      V_0
      IL_0071:  ldloca     V_0
      IL_0075:  ldind.i4
      IL_0076:  br.s       IL_0069

      IL_0078:  nop
      IL_0079:  ldarg.1
      IL_007a:  ldarg.0
      IL_007b:  ldfld      uint8[] CrackMe.Form1/eval_a::a
      IL_0080:  ldarg.2
      IL_0081:  ldelem.u1
      IL_0082:  xor
      IL_0083:  ret
    } // end of method eval_a::eval_a

    .method assembly hidebysig instance int32 
            eval_a(int32 A_0,
                   int32 A_1) cil managed
    {
      // Размер кода:       132 (0x84)
      .maxstack  3
      .locals init (int32 V_0)
      IL_0000:  ldc.i4     0xffffb7d4
      IL_0005:  stloc      V_0
      IL_0009:  ldloca     V_0
      IL_000d:  ldind.i4
      IL_000e:  ldc.i4     0xffffb7d4
      IL_0013:  stloc      V_0
      IL_0017:  ldloca     V_0
      IL_001b:  ldind.i4
      IL_001c:  ceq
      IL_001e:  switch     ( 
                            IL_002f,
                            IL_0030,
                            IL_002f)
      IL_002f:  nop
      IL_0030:  ldc.i4     0x1
      IL_0035:  stloc      V_0
      IL_0039:  ldloca     V_0
      IL_003d:  ldind.i4
      IL_003e:  br.s       IL_004c

      IL_0040:  ldc.i4.0
      IL_0041:  stloc      V_0
      IL_0045:  ldloca     V_0
      IL_0049:  ldind.i4
      IL_004a:  br.s       IL_004c

      IL_004c:  brfalse.s  IL_004e

      IL_004e:  ldc.i4.0
      IL_004f:  stloc      V_0
      IL_0053:  ldloca     V_0
      IL_0057:  ldind.i4
      IL_0058:  brfalse    IL_005d

      IL_005d:  br.s       IL_006c

      IL_005f:  ldc.i4.0
      IL_0060:  stloc      V_0
      IL_0064:  ldloca     V_0
      IL_0068:  ldind.i4
      IL_0069:  pop
      IL_006a:  br.s       IL_0078

      IL_006c:  ldc.i4.0
      IL_006d:  stloc      V_0
      IL_0071:  ldloca     V_0
      IL_0075:  ldind.i4
      IL_0076:  br.s       IL_0069

      IL_0078:  nop
      IL_0079:  ldarg.1
      IL_007a:  ldarg.0
      IL_007b:  ldfld      int32[] CrackMe.Form1/eval_a::b
      IL_0080:  ldarg.2
      IL_0081:  ldelem.i4
      IL_0082:  sub
      IL_0083:  ret
    } // end of method eval_a::eval_a

  } // end of class eval_a

  .class auto ansi serializable sealed nested private beforefieldinit '<>c'
         extends [mscorlib]System.Object
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public static initonly class CrackMe.Form1/'<>c' '<>9'
    .field public static class [System.Core]System.Func`2<int32,int32> '<>9__3_1'
    .field public static class [System.Core]System.Func`2<int32,bool> '<>9__3_3'
    .field privatescope notserialized string eval_a$PST04000012 = uint8(0x20)
    .method private hidebysig specialname rtspecialname static 
            void  .cctor() cil managed
    {
      // Размер кода:       132 (0x84)
      .maxstack  2
      .locals init (int32 V_0)
      IL_0000:  ldc.i4     0x791c
      IL_0005:  stloc      V_0
      IL_0009:  ldloca     V_0
      IL_000d:  ldind.i4
      IL_000e:  ldc.i4     0x791c
      IL_0013:  stloc      V_0
      IL_0017:  ldloca     V_0
      IL_001b:  ldind.i4
      IL_001c:  ceq
      IL_001e:  switch     ( 
                            IL_002f,
                            IL_0030,
                            IL_002f)
      IL_002f:  nop
      IL_0030:  ldc.i4     0x1
      IL_0035:  stloc      V_0
      IL_0039:  ldloca     V_0
      IL_003d:  ldind.i4
      IL_003e:  br.s       IL_004c

      IL_0040:  ldc.i4.0
      IL_0041:  stloc      V_0
      IL_0045:  ldloca     V_0
      IL_0049:  ldind.i4
      IL_004a:  br.s       IL_004c

      IL_004c:  brfalse.s  IL_004e

      IL_004e:  ldc.i4.0
      IL_004f:  stloc      V_0
      IL_0053:  ldloca     V_0
      IL_0057:  ldind.i4
      IL_0058:  brfalse    IL_005d

      IL_005d:  br.s       IL_006c

      IL_005f:  ldc.i4.0
      IL_0060:  stloc      V_0
      IL_0064:  ldloca     V_0
      IL_0068:  ldind.i4
      IL_0069:  pop
      IL_006a:  br.s       IL_0078

      IL_006c:  ldc.i4.0
      IL_006d:  stloc      V_0
      IL_0071:  ldloca     V_0
      IL_0075:  ldind.i4
      IL_0076:  br.s       IL_0069

      IL_0078:  nop
      IL_0079:  newobj     instance void CrackMe.Form1/'<>c'::.ctor()
      IL_007e:  stsfld     class CrackMe.Form1/'<>c' CrackMe.Form1/'<>c'::'<>9'
      IL_0083:  ret
    } // end of method '<>c'::.cctor

    .method public hidebysig specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Размер кода:       7 (0x7)
      .maxstack  1
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ret
    } // end of method '<>c'::.ctor

    .method assembly hidebysig instance int32 
            eval_a(int32 A_0) cil managed
    {
      // Размер кода:       141 (0x8d)
      .maxstack  2
      .locals init (int32 V_0)
      IL_0000:  ldarg.1
      IL_0001:  ldc.i4     0x3e7
      IL_0006:  bgt        IL_008b

      IL_000b:  ldc.i4     0x43d1
      IL_0010:  stloc      V_0
      IL_0014:  ldloca     V_0
      IL_0018:  ldind.i4
      IL_0019:  ldc.i4     0x43d1
      IL_001e:  stloc      V_0
      IL_0022:  ldloca     V_0
      IL_0026:  ldind.i4
      IL_0027:  ceq
      IL_0029:  switch     ( 
                            IL_008b,
                            IL_003b,
                            IL_008b)
      IL_003a:  nop
      IL_003b:  ldc.i4.0
      IL_003c:  stloc      V_0
      IL_0040:  ldloca     V_0
      IL_0044:  ldind.i4
      IL_0045:  brfalse    IL_004a

      IL_004a:  br.s       IL_0059

      IL_004c:  ldc.i4.0
      IL_004d:  stloc      V_0
      IL_0051:  ldloca     V_0
      IL_0055:  ldind.i4
      IL_0056:  pop
      IL_0057:  br.s       IL_0065

      IL_0059:  ldc.i4.0
      IL_005a:  stloc      V_0
      IL_005e:  ldloca     V_0
      IL_0062:  ldind.i4
      IL_0063:  br.s       IL_0056

      IL_0065:  nop
      IL_0066:  ldc.i4     0x1
      IL_006b:  stloc      V_0
      IL_006f:  ldloca     V_0
      IL_0073:  ldind.i4
      IL_0074:  br.s       IL_0082

      IL_0076:  ldc.i4.0
      IL_0077:  stloc      V_0
      IL_007b:  ldloca     V_0
      IL_007f:  ldind.i4
      IL_0080:  br.s       IL_0082

      IL_0082:  brfalse.s  IL_0084

      IL_0084:  br.s       IL_0086

      IL_0086:  ldarg.1
      IL_0087:  ldc.i4.s   10
      IL_0089:  mul
      IL_008a:  ret

      IL_008b:  ldarg.1
      IL_008c:  ret
    } // end of method '<>c'::eval_a

    .method assembly hidebysig instance bool 
            eval_b(int32 A_0) cil managed
    {
      // Размер кода:       126 (0x7e)
      .maxstack  2
      .locals init (int32 V_0)
      IL_0000:  ldc.i4     0x35e
      IL_0005:  stloc      V_0
      IL_0009:  ldloca     V_0
      IL_000d:  ldind.i4
      IL_000e:  ldc.i4     0x35e
      IL_0013:  stloc      V_0
      IL_0017:  ldloca     V_0
      IL_001b:  ldind.i4
      IL_001c:  ceq
      IL_001e:  switch     ( 
                            IL_002f,
                            IL_0030,
                            IL_002f)
      IL_002f:  nop
      IL_0030:  ldc.i4     0x1
      IL_0035:  stloc      V_0
      IL_0039:  ldloca     V_0
      IL_003d:  ldind.i4
      IL_003e:  br.s       IL_004c

      IL_0040:  ldc.i4.0
      IL_0041:  stloc      V_0
      IL_0045:  ldloca     V_0
      IL_0049:  ldind.i4
      IL_004a:  br.s       IL_004c

      IL_004c:  brfalse.s  IL_004e

      IL_004e:  ldc.i4.0
      IL_004f:  stloc      V_0
      IL_0053:  ldloca     V_0
      IL_0057:  ldind.i4
      IL_0058:  brfalse    IL_005d

      IL_005d:  br.s       IL_006c

      IL_005f:  ldc.i4.0
      IL_0060:  stloc      V_0
      IL_0064:  ldloca     V_0
      IL_0068:  ldind.i4
      IL_0069:  pop
      IL_006a:  br.s       IL_0078

      IL_006c:  ldc.i4.0
      IL_006d:  stloc      V_0
      IL_0071:  ldloca     V_0
      IL_0075:  ldind.i4
      IL_0076:  br.s       IL_0069

      IL_0078:  nop
      IL_0079:  ldarg.1
      IL_007a:  ldc.i4.0
      IL_007b:  ceq
      IL_007d:  ret
    } // end of method '<>c'::eval_b

  } // end of class '<>c'

  .field private string[] a
  .field private class [System]System.ComponentModel.IContainer eval_b
  .field private class [System.Windows.Forms]System.Windows.Forms.Button eval_c
  .field private class [System.Windows.Forms]System.Windows.Forms.TextBox eval_d
  .field private class [System.Windows.Forms]System.Windows.Forms.Label eval_e
  .field private class [System.Windows.Forms]System.Windows.Forms.Label eval_f
  .field privatescope notserialized string eval_g$PST0400000A = uint8(0x20)
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       13 (0xd)
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Windows.Forms]System.Windows.Forms.Form::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  call       instance void CrackMe.Form1::eval_a()
    IL_000c:  ret
  } // end of method Form1::.ctor

  .method private hidebysig instance void 
          eval_a(object A_0,
                 class [mscorlib]System.EventArgs A_1) cil managed
  {
    // Размер кода:       326 (0x146)
    .maxstack  6
    .locals init (int32 V_0,
             int32 V_1)
    IL_0000:  ldc.i4.0
    IL_0001:  stloc      V_1
    IL_0005:  ldloca     V_1
    IL_0009:  ldind.i4
    IL_000a:  stloc.0
    IL_000b:  br.s       IL_0017

    IL_000d:  ldc.i4.0
    IL_000e:  switch     ( 
                          IL_0029)
    IL_0017:  ldloc.0
    IL_0018:  switch     ( 
                          IL_000d,
                          IL_0110,
                          IL_004f)
    IL_0029:  ldarg.0
    IL_002a:  ldfld      class [System.Windows.Forms]System.Windows.Forms.TextBox CrackMe.Form1::eval_d
    IL_002f:  callvirt   instance string [System.Windows.Forms]System.Windows.Forms.Control::get_Text()
    IL_0034:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_0039:  brfalse    IL_00db

    IL_003e:  ldc.i4     0x2
    IL_0043:  stloc      V_1
    IL_0047:  ldloca     V_1
    IL_004b:  ldind.i4
    IL_004c:  stloc.0
    IL_004d:  br.s       IL_0017

    IL_004f:  ldc.i4     0x1
    IL_0054:  stloc      V_1
    IL_0058:  ldloca     V_1
    IL_005c:  ldind.i4
    IL_005d:  br.s       IL_006b

    IL_005f:  ldc.i4.0
    IL_0060:  stloc      V_1
    IL_0064:  ldloca     V_1
    IL_0068:  ldind.i4
    IL_0069:  br.s       IL_006b

    IL_006b:  brfalse.s  IL_006d

    IL_006d:  br.s       IL_007c

    IL_006f:  ldc.i4.0
    IL_0070:  stloc      V_1
    IL_0074:  ldloca     V_1
    IL_0078:  ldind.i4
    IL_0079:  pop
    IL_007a:  br.s       IL_0088

    IL_007c:  ldc.i4.0
    IL_007d:  stloc      V_1
    IL_0081:  ldloca     V_1
    IL_0085:  ldind.i4
    IL_0086:  br.s       IL_0079

    IL_0088:  nop
    IL_0089:  br.s       IL_008b

    IL_008b:  ldc.i4     0xffff987c
    IL_0090:  stloc      V_1
    IL_0094:  ldloca     V_1
    IL_0098:  ldind.i4
    IL_0099:  ldc.i4     0xffff987c
    IL_009e:  stloc      V_1
    IL_00a2:  ldloca     V_1
    IL_00a6:  ldind.i4
    IL_00a7:  ceq
    IL_00a9:  switch     ( 
                          IL_000d,
                          IL_00bb,
                          IL_000d)
    IL_00ba:  nop
    IL_00bb:  ldc.i4.0
    IL_00bc:  stloc      V_1
    IL_00c0:  ldloca     V_1
    IL_00c4:  ldind.i4
    IL_00c5:  brfalse    IL_00ca

    IL_00ca:  ldarg.0
    IL_00cb:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_f
    IL_00d0:  ldstr      "Key cannot be empty"
    IL_00d5:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
    IL_00da:  ret

    IL_00db:  ldarg.0
    IL_00dc:  ldarg.0
    IL_00dd:  ldfld      class [System.Windows.Forms]System.Windows.Forms.TextBox CrackMe.Form1::eval_d
    IL_00e2:  callvirt   instance string [System.Windows.Forms]System.Windows.Forms.Control::get_Text()
    IL_00e7:  ldc.i4.1
    IL_00e8:  newarr     [mscorlib]System.Char
    IL_00ed:  dup
    IL_00ee:  ldc.i4.0
    IL_00ef:  ldc.i4.s   45
    IL_00f1:  stelem.i2
    IL_00f2:  callvirt   instance string[] [mscorlib]System.String::Split(char[])
    IL_00f7:  stfld      string[] CrackMe.Form1::a
    IL_00fc:  ldc.i4     0x1
    IL_0101:  stloc      V_1
    IL_0105:  ldloca     V_1
    IL_0109:  ldind.i4
    IL_010a:  stloc.0
    IL_010b:  br         IL_0017

    IL_0110:  ldarg.0
    IL_0111:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_f
    IL_0116:  ldarg.0
    IL_0117:  ldarg.0
    IL_0118:  ldfld      string[] CrackMe.Form1::a
    IL_011d:  call       instance bool CrackMe.Form1::eval_a(string[])
    IL_0122:  brtrue.s   IL_012d

    IL_0124:  br.s       IL_0126

    IL_0126:  ldstr      "Wrong key"
    IL_012b:  br.s       IL_0134

    IL_012d:  ldstr      "Correct key"
    IL_0132:  br.s       IL_0134

    IL_0134:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
    IL_0139:  ldarg.0
    IL_013a:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_f
    IL_013f:  ldc.i4.1
    IL_0140:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Visible(bool)
    IL_0145:  ret
  } // end of method Form1::eval_a

  .method private hidebysig instance bool 
          eval_a(string[] A_0) cil managed
  {
    // Размер кода:       442 (0x1ba)
    .maxstack  5
    .locals init (class CrackMe.Form1/eval_a V_0,
             class [System]System.Net.NetworkInformation.NetworkInterface V_1,
             valuetype [mscorlib]System.DateTime V_2,
             int32 V_3,
             int32 V_4)
    IL_0000:  ldc.i4.0
    IL_0001:  switch     ( 
                          IL_0020)
    IL_000a:  ldloc.3
    IL_000b:  switch     ( 
                          IL_003e,
                          IL_00c8,
                          IL_00b2,
                          IL_013e)
    IL_0020:  newobj     instance void CrackMe.Form1/eval_a::.ctor()
    IL_0025:  stloc.0
    IL_0026:  call       class [System]System.Net.NetworkInformation.NetworkInterface[] [System]System.Net.NetworkInformation.NetworkInterface::GetAllNetworkInterfaces()
    IL_002b:  call       !!0 [System.Core]System.Linq.Enumerable::FirstOrDefault<class [System]System.Net.NetworkInformation.NetworkInterface>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    IL_0030:  stloc.1
    IL_0031:  ldc.i4.0
    IL_0032:  stloc      V_4
    IL_0036:  ldloca     V_4
    IL_003a:  ldind.i4
    IL_003b:  stloc.3
    IL_003c:  br.s       IL_000a

    IL_003e:  ldc.i4     0xffffa9db
    IL_0043:  stloc      V_4
    IL_0047:  ldloca     V_4
    IL_004b:  ldind.i4
    IL_004c:  ldc.i4     0xffffa9db
    IL_0051:  stloc      V_4
    IL_0055:  ldloca     V_4
    IL_0059:  ldind.i4
    IL_005a:  ceq
    IL_005c:  switch     ( 
                          IL_012a,
                          IL_006e,
                          IL_012a)
    IL_006d:  nop
    IL_006e:  ldc.i4     0x1
    IL_0073:  stloc      V_4
    IL_0077:  ldloca     V_4
    IL_007b:  ldind.i4
    IL_007c:  br.s       IL_008a

    IL_007e:  ldc.i4.0
    IL_007f:  stloc      V_4
    IL_0083:  ldloca     V_4
    IL_0087:  ldind.i4
    IL_0088:  br.s       IL_008a

    IL_008a:  brfalse.s  IL_008c

    IL_008c:  ldc.i4.0
    IL_008d:  stloc      V_4
    IL_0091:  ldloca     V_4
    IL_0095:  ldind.i4
    IL_0096:  brfalse    IL_009b

    IL_009b:  ldloc.1
    IL_009c:  brtrue.s   IL_00b4

    IL_009e:  ldc.i4     0x2
    IL_00a3:  stloc      V_4
    IL_00a7:  ldloca     V_4
    IL_00ab:  ldind.i4
    IL_00ac:  stloc.3
    IL_00ad:  br         IL_000a

    IL_00b2:  br.s       IL_012a

    IL_00b4:  ldc.i4     0x1
    IL_00b9:  stloc      V_4
    IL_00bd:  ldloca     V_4
    IL_00c1:  ldind.i4
    IL_00c2:  stloc.3
    IL_00c3:  br         IL_000a

    IL_00c8:  br.s       IL_00d7

    IL_00ca:  ldc.i4.0
    IL_00cb:  stloc      V_4
    IL_00cf:  ldloca     V_4
    IL_00d3:  ldind.i4
    IL_00d4:  pop
    IL_00d5:  br.s       IL_00e3

    IL_00d7:  ldc.i4.0
    IL_00d8:  stloc      V_4
    IL_00dc:  ldloca     V_4
    IL_00e0:  ldind.i4
    IL_00e1:  br.s       IL_00d4

    IL_00e3:  nop
    IL_00e4:  ldloc.1
    IL_00e5:  callvirt   instance class [System]System.Net.NetworkInformation.PhysicalAddress [System]System.Net.NetworkInformation.NetworkInterface::GetPhysicalAddress()
    IL_00ea:  callvirt   instance uint8[] [System]System.Net.NetworkInformation.PhysicalAddress::GetAddressBytes()
    IL_00ef:  ldloc.0
    IL_00f0:  call       valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
    IL_00f5:  stloc.2
    IL_00f6:  ldloca.s   V_2
    IL_00f8:  call       instance valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Date()
    IL_00fd:  stloc.2
    IL_00fe:  ldloca.s   V_2
    IL_0100:  call       instance int64 [mscorlib]System.DateTime::ToBinary()
    IL_0105:  call       uint8[] [mscorlib]System.BitConverter::GetBytes(int64)
    IL_010a:  stfld      uint8[] CrackMe.Form1/eval_a::a
    IL_010f:  ldloc.0
    IL_0110:  ldftn      instance int32 CrackMe.Form1/eval_a::eval_a(uint8,
                                                                     int32)
    IL_0116:  newobj     instance void class [System.Core]System.Func`3<uint8,int32,int32>::.ctor(object,
                                                                                                  native int)
    IL_011b:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<!!1> [System.Core]System.Linq.Enumerable::Select<uint8,int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                                                                                class [System.Core]System.Func`3<!!0,int32,!!1>)
    IL_0120:  ldsfld     class [System.Core]System.Func`2<int32,int32> CrackMe.Form1/'<>c'::'<>9__3_1'
    IL_0125:  dup
    IL_0126:  brtrue.s   IL_0140

    IL_0128:  br.s       IL_0182

    IL_012a:  ldc.i4     0x3
    IL_012f:  stloc      V_4
    IL_0133:  ldloca     V_4
    IL_0137:  ldind.i4
    IL_0138:  stloc.3
    IL_0139:  br         IL_000a

    IL_013e:  ldc.i4.0
    IL_013f:  ret

    IL_0140:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<!!1> [System.Core]System.Linq.Enumerable::Select<int32,int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                                                                                class [System.Core]System.Func`2<!!0,!!1>)
    IL_0145:  call       !!0[] [System.Core]System.Linq.Enumerable::ToArray<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    IL_014a:  ldloc.0
    IL_014b:  ldarg.1
    IL_014c:  ldnull
    IL_014d:  ldftn      int32 [mscorlib]System.Int32::Parse(string)
    IL_0153:  newobj     instance void class [System.Core]System.Func`2<string,int32>::.ctor(object,
                                                                                             native int)
    IL_0158:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<!!1> [System.Core]System.Linq.Enumerable::Select<string,int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                                                                                 class [System.Core]System.Func`2<!!0,!!1>)
    IL_015d:  call       !!0[] [System.Core]System.Linq.Enumerable::ToArray<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    IL_0162:  stfld      int32[] CrackMe.Form1/eval_a::b
    IL_0167:  ldloc.0
    IL_0168:  ldftn      instance int32 CrackMe.Form1/eval_a::eval_a(int32,
                                                                     int32)
    IL_016e:  newobj     instance void class [System.Core]System.Func`3<int32,int32,int32>::.ctor(object,
                                                                                                  native int)
    IL_0173:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<!!1> [System.Core]System.Linq.Enumerable::Select<int32,int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                                                                                class [System.Core]System.Func`3<!!0,int32,!!1>)
    IL_0178:  ldsfld     class [System.Core]System.Func`2<int32,bool> CrackMe.Form1/'<>c'::'<>9__3_3'
    IL_017d:  dup
    IL_017e:  brtrue.s   IL_01b4

    IL_0180:  br.s       IL_019b

    IL_0182:  pop
    IL_0183:  ldsfld     class CrackMe.Form1/'<>c' CrackMe.Form1/'<>c'::'<>9'
    IL_0188:  ldftn      instance int32 CrackMe.Form1/'<>c'::eval_a(int32)
    IL_018e:  newobj     instance void class [System.Core]System.Func`2<int32,int32>::.ctor(object,
                                                                                            native int)
    IL_0193:  dup
    IL_0194:  stsfld     class [System.Core]System.Func`2<int32,int32> CrackMe.Form1/'<>c'::'<>9__3_1'
    IL_0199:  br.s       IL_0140

    IL_019b:  pop
    IL_019c:  ldsfld     class CrackMe.Form1/'<>c' CrackMe.Form1/'<>c'::'<>9'
    IL_01a1:  ldftn      instance bool CrackMe.Form1/'<>c'::eval_b(int32)
    IL_01a7:  newobj     instance void class [System.Core]System.Func`2<int32,bool>::.ctor(object,
                                                                                           native int)
    IL_01ac:  dup
    IL_01ad:  stsfld     class [System.Core]System.Func`2<int32,bool> CrackMe.Form1/'<>c'::'<>9__3_3'
    IL_01b2:  br.s       IL_01b4

    IL_01b4:  call       bool [System.Core]System.Linq.Enumerable::All<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                              class [System.Core]System.Func`2<!!0,bool>)
    IL_01b9:  ret
  } // end of method Form1::eval_a

  .method family hidebysig virtual instance void 
          Dispose(bool disposing) cil managed
  {
    // Размер кода:       289 (0x121)
    .maxstack  2
    .locals init (int32 V_0,
             int32 V_1)
    IL_0000:  ldc.i4     0x2
    IL_0005:  stloc      V_1
    IL_0009:  ldloca     V_1
    IL_000d:  ldind.i4
    IL_000e:  stloc.0
    IL_000f:  br.s       IL_001b

    IL_0011:  ldc.i4.0
    IL_0012:  switch     ( 
                          IL_0051)
    IL_001b:  br.s       IL_002a

    IL_001d:  ldc.i4.0
    IL_001e:  stloc      V_1
    IL_0022:  ldloca     V_1
    IL_0026:  ldind.i4
    IL_0027:  pop
    IL_0028:  br.s       IL_0036

    IL_002a:  ldc.i4.0
    IL_002b:  stloc      V_1
    IL_002f:  ldloca     V_1
    IL_0033:  ldind.i4
    IL_0034:  br.s       IL_0027

    IL_0036:  nop
    IL_0037:  ldloc.0
    IL_0038:  switch     ( 
                          IL_00a6,
                          IL_00c7,
                          IL_0011,
                          IL_0117,
                          IL_00dd)
    IL_0051:  ldarg.1
    IL_0052:  brfalse    IL_0119

    IL_0057:  ldc.i4     0x34b2
    IL_005c:  stloc      V_1
    IL_0060:  ldloca     V_1
    IL_0064:  ldind.i4
    IL_0065:  ldc.i4     0x34b2
    IL_006a:  stloc      V_1
    IL_006e:  ldloca     V_1
    IL_0072:  ldind.i4
    IL_0073:  ceq
    IL_0075:  switch     ( 
                          IL_00a8,
                          IL_0087,
                          IL_00a8)
    IL_0086:  nop
    IL_0087:  ldc.i4.0
    IL_0088:  stloc      V_1
    IL_008c:  ldloca     V_1
    IL_0090:  ldind.i4
    IL_0091:  brfalse    IL_0096

    IL_0096:  ldc.i4.0
    IL_0097:  stloc      V_1
    IL_009b:  ldloca     V_1
    IL_009f:  ldind.i4
    IL_00a0:  stloc.0
    IL_00a1:  br         IL_001b

    IL_00a6:  br.s       IL_00c9

    IL_00a8:  ldarg.0
    IL_00a9:  ldfld      class [System]System.ComponentModel.IContainer CrackMe.Form1::eval_b
    IL_00ae:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
    IL_00b3:  ldc.i4     0x1
    IL_00b8:  stloc      V_1
    IL_00bc:  ldloca     V_1
    IL_00c0:  ldind.i4
    IL_00c1:  stloc.0
    IL_00c2:  br         IL_001b

    IL_00c7:  br.s       IL_0119

    IL_00c9:  ldc.i4     0x4
    IL_00ce:  stloc      V_1
    IL_00d2:  ldloca     V_1
    IL_00d6:  ldind.i4
    IL_00d7:  stloc.0
    IL_00d8:  br         IL_001b

    IL_00dd:  ldc.i4     0x1
    IL_00e2:  stloc      V_1
    IL_00e6:  ldloca     V_1
    IL_00ea:  ldind.i4
    IL_00eb:  br.s       IL_00f9

    IL_00ed:  ldc.i4.0
    IL_00ee:  stloc      V_1
    IL_00f2:  ldloca     V_1
    IL_00f6:  ldind.i4
    IL_00f7:  br.s       IL_00f9

    IL_00f9:  brfalse.s  IL_00fb

    IL_00fb:  ldarg.0
    IL_00fc:  ldfld      class [System]System.ComponentModel.IContainer CrackMe.Form1::eval_b
    IL_0101:  brfalse.s  IL_0119

    IL_0103:  ldc.i4     0x3
    IL_0108:  stloc      V_1
    IL_010c:  ldloca     V_1
    IL_0110:  ldind.i4
    IL_0111:  stloc.0
    IL_0112:  br         IL_001b

    IL_0117:  br.s       IL_00a8

    IL_0119:  ldarg.0
    IL_011a:  ldarg.1
    IL_011b:  call       instance void [System.Windows.Forms]System.Windows.Forms.Form::Dispose(bool)
    IL_0120:  ret
  } // end of method Form1::Dispose

  .method private hidebysig instance void 
          eval_a() cil managed
  {
    // Размер кода:       723 (0x2d3)
    .maxstack  3
    .locals init (int32 V_0)
    IL_0000:  ldc.i4     0x3b79
    IL_0005:  stloc      V_0
    IL_0009:  ldloca     V_0
    IL_000d:  ldind.i4
    IL_000e:  ldc.i4     0x3b79
    IL_0013:  stloc      V_0
    IL_0017:  ldloca     V_0
    IL_001b:  ldind.i4
    IL_001c:  ceq
    IL_001e:  switch     ( 
                          IL_002f,
                          IL_0030,
                          IL_002f)
    IL_002f:  nop
    IL_0030:  ldc.i4.0
    IL_0031:  stloc      V_0
    IL_0035:  ldloca     V_0
    IL_0039:  ldind.i4
    IL_003a:  brfalse    IL_003f

    IL_003f:  ldc.i4     0x1
    IL_0044:  stloc      V_0
    IL_0048:  ldloca     V_0
    IL_004c:  ldind.i4
    IL_004d:  br.s       IL_005b

    IL_004f:  ldc.i4.0
    IL_0050:  stloc      V_0
    IL_0054:  ldloca     V_0
    IL_0058:  ldind.i4
    IL_0059:  br.s       IL_005b

    IL_005b:  brfalse.s  IL_005d

    IL_005d:  br.s       IL_006c

    IL_005f:  ldc.i4.0
    IL_0060:  stloc      V_0
    IL_0064:  ldloca     V_0
    IL_0068:  ldind.i4
    IL_0069:  pop
    IL_006a:  br.s       IL_0078

    IL_006c:  ldc.i4.0
    IL_006d:  stloc      V_0
    IL_0071:  ldloca     V_0
    IL_0075:  ldind.i4
    IL_0076:  br.s       IL_0069

    IL_0078:  nop
    IL_0079:  ldarg.0
    IL_007a:  newobj     instance void [System.Windows.Forms]System.Windows.Forms.Button::.ctor()
    IL_007f:  stfld      class [System.Windows.Forms]System.Windows.Forms.Button CrackMe.Form1::eval_c
    IL_0084:  ldarg.0
    IL_0085:  newobj     instance void [System.Windows.Forms]System.Windows.Forms.TextBox::.ctor()
    IL_008a:  stfld      class [System.Windows.Forms]System.Windows.Forms.TextBox CrackMe.Form1::eval_d
    IL_008f:  ldarg.0
    IL_0090:  newobj     instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
    IL_0095:  stfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_e
    IL_009a:  ldarg.0
    IL_009b:  newobj     instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
    IL_00a0:  stfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_f
    IL_00a5:  ldarg.0
    IL_00a6:  call       instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
    IL_00ab:  ldarg.0
    IL_00ac:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Button CrackMe.Form1::eval_c
    IL_00b1:  ldc.i4     0x10c
    IL_00b6:  ldc.i4.s   51
    IL_00b8:  newobj     instance void [System.Drawing]System.Drawing.Point::.ctor(int32,
                                                                                   int32)
    IL_00bd:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
    IL_00c2:  ldarg.0
    IL_00c3:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Button CrackMe.Form1::eval_c
    IL_00c8:  nop
    IL_00c9:  ldstr      "bt_check"
    IL_00ce:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
    IL_00d3:  ldarg.0
    IL_00d4:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Button CrackMe.Form1::eval_c
    IL_00d9:  ldc.i4.s   75
    IL_00db:  ldc.i4.s   23
    IL_00dd:  newobj     instance void [System.Drawing]System.Drawing.Size::.ctor(int32,
                                                                                  int32)
    IL_00e2:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
    IL_00e7:  ldarg.0
    IL_00e8:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Button CrackMe.Form1::eval_c
    IL_00ed:  ldc.i4.0
    IL_00ee:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
    IL_00f3:  ldarg.0
    IL_00f4:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Button CrackMe.Form1::eval_c
    IL_00f9:  ldstr      "Check"
    IL_00fe:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
    IL_0103:  ldarg.0
    IL_0104:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Button CrackMe.Form1::eval_c
    IL_0109:  ldc.i4.1
    IL_010a:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.ButtonBase::set_UseVisualStyleBackColor(bool)
    IL_010f:  ldarg.0
    IL_0110:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Button CrackMe.Form1::eval_c
    IL_0115:  ldarg.0
    IL_0116:  ldftn      instance void CrackMe.Form1::eval_a(object,
                                                             class [mscorlib]System.EventArgs)
    IL_011c:  newobj     instance void [mscorlib]System.EventHandler::.ctor(object,
                                                                            native int)
    IL_0121:  nop
    IL_0122:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::add_Click(class [mscorlib]System.EventHandler)
    IL_0127:  ldarg.0
    IL_0128:  ldfld      class [System.Windows.Forms]System.Windows.Forms.TextBox CrackMe.Form1::eval_d
    IL_012d:  ldc.i4.s   35
    IL_012f:  ldc.i4.s   25
    IL_0131:  newobj     instance void [System.Drawing]System.Drawing.Point::.ctor(int32,
                                                                                   int32)
    IL_0136:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
    IL_013b:  ldarg.0
    IL_013c:  ldfld      class [System.Windows.Forms]System.Windows.Forms.TextBox CrackMe.Form1::eval_d
    IL_0141:  nop
    IL_0142:  ldstr      "tb_key"
    IL_0147:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
    IL_014c:  ldarg.0
    IL_014d:  ldfld      class [System.Windows.Forms]System.Windows.Forms.TextBox CrackMe.Form1::eval_d
    IL_0152:  ldc.i4     0x134
    IL_0157:  ldc.i4.s   20
    IL_0159:  newobj     instance void [System.Drawing]System.Drawing.Size::.ctor(int32,
                                                                                  int32)
    IL_015e:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
    IL_0163:  ldarg.0
    IL_0164:  ldfld      class [System.Windows.Forms]System.Windows.Forms.TextBox CrackMe.Form1::eval_d
    IL_0169:  ldc.i4.1
    IL_016a:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
    IL_016f:  ldarg.0
    IL_0170:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_e
    IL_0175:  ldc.i4.1
    IL_0176:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
    IL_017b:  ldarg.0
    IL_017c:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_e
    IL_0181:  ldc.i4.s   32
    IL_0183:  ldc.i4.s   9
    IL_0185:  newobj     instance void [System.Drawing]System.Drawing.Point::.ctor(int32,
                                                                                   int32)
    IL_018a:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
    IL_018f:  ldarg.0
    IL_0190:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_e
    IL_0195:  nop
    IL_0196:  ldstr      "label1"
    IL_019b:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
    IL_01a0:  ldarg.0
    IL_01a1:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_e
    IL_01a6:  ldc.i4.s   107
    IL_01a8:  ldc.i4.s   13
    IL_01aa:  newobj     instance void [System.Drawing]System.Drawing.Size::.ctor(int32,
                                                                                  int32)
    IL_01af:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
    IL_01b4:  ldarg.0
    IL_01b5:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_e
    IL_01ba:  ldc.i4.2
    IL_01bb:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
    IL_01c0:  ldarg.0
    IL_01c1:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_e
    IL_01c6:  ldstr      "Please, enter the key"
    IL_01cb:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
    IL_01d0:  ldarg.0
    IL_01d1:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_f
    IL_01d6:  ldc.i4.1
    IL_01d7:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
    IL_01dc:  ldarg.0
    IL_01dd:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_f
    IL_01e2:  ldc.i4.s   35
    IL_01e4:  ldc.i4.s   52
    IL_01e6:  newobj     instance void [System.Drawing]System.Drawing.Point::.ctor(int32,
                                                                                   int32)
    IL_01eb:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
    IL_01f0:  ldarg.0
    IL_01f1:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_f
    IL_01f6:  nop
    IL_01f7:  ldstr      "lb_status"
    IL_01fc:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
    IL_0201:  ldarg.0
    IL_0202:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_f
    IL_0207:  ldc.i4.s   35
    IL_0209:  ldc.i4.s   13
    IL_020b:  newobj     instance void [System.Drawing]System.Drawing.Size::.ctor(int32,
                                                                                  int32)
    IL_0210:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
    IL_0215:  ldarg.0
    IL_0216:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_f
    IL_021b:  ldc.i4.3
    IL_021c:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
    IL_0221:  ldarg.0
    IL_0222:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_f
    IL_0227:  ldstr      "label2"
    IL_022c:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
    IL_0231:  ldarg.0
    IL_0232:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_f
    IL_0237:  ldc.i4.0
    IL_0238:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Visible(bool)
    IL_023d:  ldarg.0
    IL_023e:  ldc.r4     6.
    IL_0243:  ldc.r4     13.
    IL_0248:  newobj     instance void [System.Drawing]System.Drawing.SizeF::.ctor(float32,
                                                                                   float32)
    IL_024d:  call       instance void [System.Windows.Forms]System.Windows.Forms.ContainerControl::set_AutoScaleDimensions(valuetype [System.Drawing]System.Drawing.SizeF)
    IL_0252:  ldarg.0
    IL_0253:  ldc.i4.1
    IL_0254:  call       instance void [System.Windows.Forms]System.Windows.Forms.ContainerControl::set_AutoScaleMode(valuetype [System.Windows.Forms]System.Windows.Forms.AutoScaleMode)
    IL_0259:  ldarg.0
    IL_025a:  ldc.i4     0x171
    IL_025f:  ldc.i4.s   86
    IL_0261:  newobj     instance void [System.Drawing]System.Drawing.Size::.ctor(int32,
                                                                                  int32)
    IL_0266:  call       instance void [System.Windows.Forms]System.Windows.Forms.Form::set_ClientSize(valuetype [System.Drawing]System.Drawing.Size)
    IL_026b:  ldarg.0
    IL_026c:  call       instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
    IL_0271:  ldarg.0
    IL_0272:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_f
    IL_0277:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
    IL_027c:  ldarg.0
    IL_027d:  call       instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
    IL_0282:  ldarg.0
    IL_0283:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Label CrackMe.Form1::eval_e
    IL_0288:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
    IL_028d:  ldarg.0
    IL_028e:  call       instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
    IL_0293:  ldarg.0
    IL_0294:  ldfld      class [System.Windows.Forms]System.Windows.Forms.TextBox CrackMe.Form1::eval_d
    IL_0299:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
    IL_029e:  ldarg.0
    IL_029f:  call       instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
    IL_02a4:  ldarg.0
    IL_02a5:  ldfld      class [System.Windows.Forms]System.Windows.Forms.Button CrackMe.Form1::eval_c
    IL_02aa:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
    IL_02af:  ldarg.0
    IL_02b0:  ldstr      "Form1"
    IL_02b5:  call       instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
    IL_02ba:  ldarg.0
    IL_02bb:  ldstr      "Crack me"
    IL_02c0:  callvirt   instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
    IL_02c5:  ldarg.0
    IL_02c6:  ldc.i4.0
    IL_02c7:  call       instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
    IL_02cc:  ldarg.0
    IL_02cd:  call       instance void [System.Windows.Forms]System.Windows.Forms.Control::PerformLayout()
    IL_02d2:  ret
  } // end of method Form1::eval_a

} // end of class CrackMe.Form1

.class private abstract auto ansi sealed beforefieldinit eval_a
       extends [mscorlib]System.Object
{
  .field private notserialized string eval_a = uint8(0x20)
  .method private hidebysig static void  a() cil managed
  {
    .entrypoint
    .custom instance void [mscorlib]System.STAThreadAttribute::.ctor() = ( 01 00 00 00 ) 
    // Размер кода:       143 (0x8f)
    .maxstack  2
    .locals init (int32 V_0)
    IL_0000:  ldc.i4     0xffff82be
    IL_0005:  stloc      V_0
    IL_0009:  ldloca     V_0
    IL_000d:  ldind.i4
    IL_000e:  ldc.i4     0xffff82be
    IL_0013:  stloc      V_0
    IL_0017:  ldloca     V_0
    IL_001b:  ldind.i4
    IL_001c:  ceq
    IL_001e:  switch     ( 
                          IL_002f,
                          IL_0030,
                          IL_002f)
    IL_002f:  nop
    IL_0030:  ldc.i4.0
    IL_0031:  stloc      V_0
    IL_0035:  ldloca     V_0
    IL_0039:  ldind.i4
    IL_003a:  brfalse    IL_003f

    IL_003f:  ldc.i4     0x1
    IL_0044:  stloc      V_0
    IL_0048:  ldloca     V_0
    IL_004c:  ldind.i4
    IL_004d:  br.s       IL_005b

    IL_004f:  ldc.i4.0
    IL_0050:  stloc      V_0
    IL_0054:  ldloca     V_0
    IL_0058:  ldind.i4
    IL_0059:  br.s       IL_005b

    IL_005b:  brfalse.s  IL_005d

    IL_005d:  br.s       IL_006c

    IL_005f:  ldc.i4.0
    IL_0060:  stloc      V_0
    IL_0064:  ldloca     V_0
    IL_0068:  ldind.i4
    IL_0069:  pop
    IL_006a:  br.s       IL_0078

    IL_006c:  ldc.i4.0
    IL_006d:  stloc      V_0
    IL_0071:  ldloca     V_0
    IL_0075:  ldind.i4
    IL_0076:  br.s       IL_0069

    IL_0078:  nop
    IL_0079:  call       void [System.Windows.Forms]System.Windows.Forms.Application::EnableVisualStyles()
    IL_007e:  ldc.i4.0
    IL_007f:  call       void [System.Windows.Forms]System.Windows.Forms.Application::SetCompatibleTextRenderingDefault(bool)
    IL_0084:  newobj     instance void CrackMe.Form1::.ctor()
    IL_0089:  call       void [System.Windows.Forms]System.Windows.Forms.Application::Run(class [System.Windows.Forms]System.Windows.Forms.Form)
    IL_008e:  ret
  } // end of method eval_a::a

} // end of class eval_a

.class private auto ansi beforefieldinit CrackMe.Properties.Resources
       extends [mscorlib]System.Object
{
  .custom instance void [System]System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(string,
                                                                                      string) = ( 01 00 33 53 79 73 74 65 6D 2E 52 65 73 6F 75 72   // ..3System.Resour
                                                                                                  63 65 73 2E 54 6F 6F 6C 73 2E 53 74 72 6F 6E 67   // ces.Tools.Strong
                                                                                                  6C 79 54 79 70 65 64 52 65 73 6F 75 72 63 65 42   // lyTypedResourceB
                                                                                                  75 69 6C 64 65 72 07 34 2E 30 2E 30 2E 30 00 00 ) // uilder.4.0.0.0..
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private static class [mscorlib]System.Resources.ResourceManager eval_a
  .field private static class [mscorlib]System.Globalization.CultureInfo eval_b
  .field private notserialized string eval_c = uint8(0x20)
  .method assembly hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       7 (0x7)
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Resources::.ctor

  .method assembly hidebysig specialname static 
          class [mscorlib]System.Resources.ResourceManager 
          eval_b() cil managed
  {
    // Размер кода:       249 (0xf9)
    .maxstack  2
    .locals init (int32 V_0,
             int32 V_1)
    IL_0000:  ldc.i4     0x2
    IL_0005:  stloc      V_1
    IL_0009:  ldloca     V_1
    IL_000d:  ldind.i4
    IL_000e:  stloc.0
    IL_000f:  br.s       IL_0039

    IL_0011:  ldc.i4     0x1
    IL_0016:  stloc      V_1
    IL_001a:  ldloca     V_1
    IL_001e:  ldind.i4
    IL_001f:  br.s       IL_002d

    IL_0021:  ldc.i4.0
    IL_0022:  stloc      V_1
    IL_0026:  ldloca     V_1
    IL_002a:  ldind.i4
    IL_002b:  br.s       IL_002d

    IL_002d:  brfalse.s  IL_002f

    IL_002f:  ldc.i4.0
    IL_0030:  switch     ( 
                          IL_004b)
    IL_0039:  ldloc.0
    IL_003a:  switch     ( 
                          IL_00f1,
                          IL_00c1,
                          IL_0011)
    IL_004b:  ldc.i4     0x52ef
    IL_0050:  stloc      V_1
    IL_0054:  ldloca     V_1
    IL_0058:  ldind.i4
    IL_0059:  ldc.i4     0x52ef
    IL_005e:  stloc      V_1
    IL_0062:  ldloca     V_1
    IL_0066:  ldind.i4
    IL_0067:  ceq
    IL_0069:  switch     ( 
                          IL_00c1,
                          IL_007b,
                          IL_00c1)
    IL_007a:  nop
    IL_007b:  ldc.i4.0
    IL_007c:  stloc      V_1
    IL_0080:  ldloca     V_1
    IL_0084:  ldind.i4
    IL_0085:  brfalse    IL_008a

    IL_008a:  br.s       IL_0099

    IL_008c:  ldc.i4.0
    IL_008d:  stloc      V_1
    IL_0091:  ldloca     V_1
    IL_0095:  ldind.i4
    IL_0096:  pop
    IL_0097:  br.s       IL_00a5

    IL_0099:  ldc.i4.0
    IL_009a:  stloc      V_1
    IL_009e:  ldloca     V_1
    IL_00a2:  ldind.i4
    IL_00a3:  br.s       IL_0096

    IL_00a5:  nop
    IL_00a6:  ldsfld     class [mscorlib]System.Resources.ResourceManager CrackMe.Properties.Resources::eval_a
    IL_00ab:  brtrue.s   IL_00f3

    IL_00ad:  ldc.i4     0x1
    IL_00b2:  stloc      V_1
    IL_00b6:  ldloca     V_1
    IL_00ba:  ldind.i4
    IL_00bb:  stloc.0
    IL_00bc:  br         IL_0039

    IL_00c1:  br.s       IL_00c3

    IL_00c3:  ldstr      "CrackMe.Properties.Resources"
    IL_00c8:  ldtoken    CrackMe.Properties.Resources
    IL_00cd:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_00d2:  callvirt   instance class [mscorlib]System.Reflection.Assembly [mscorlib]System.Type::get_Assembly()
    IL_00d7:  newobj     instance void [mscorlib]System.Resources.ResourceManager::.ctor(string,
                                                                                         class [mscorlib]System.Reflection.Assembly)
    IL_00dc:  stsfld     class [mscorlib]System.Resources.ResourceManager CrackMe.Properties.Resources::eval_a
    IL_00e1:  ldc.i4.0
    IL_00e2:  stloc      V_1
    IL_00e6:  ldloca     V_1
    IL_00ea:  ldind.i4
    IL_00eb:  stloc.0
    IL_00ec:  br         IL_0039

    IL_00f1:  br.s       IL_00f3

    IL_00f3:  ldsfld     class [mscorlib]System.Resources.ResourceManager CrackMe.Properties.Resources::eval_a
    IL_00f8:  ret
  } // end of method Resources::eval_b

  .method assembly hidebysig specialname static 
          class [mscorlib]System.Globalization.CultureInfo 
          eval_a() cil managed
  {
    // Размер кода:       127 (0x7f)
    .maxstack  2
    .locals init (int32 V_0)
    IL_0000:  ldc.i4     0xffffbc7c
    IL_0005:  stloc      V_0
    IL_0009:  ldloca     V_0
    IL_000d:  ldind.i4
    IL_000e:  ldc.i4     0xffffbc7c
    IL_0013:  stloc      V_0
    IL_0017:  ldloca     V_0
    IL_001b:  ldind.i4
    IL_001c:  ceq
    IL_001e:  switch     ( 
                          IL_002f,
                          IL_004c,
                          IL_002f)
    IL_002f:  br.s       IL_003e

    IL_0031:  ldc.i4.0
    IL_0032:  stloc      V_0
    IL_0036:  ldloca     V_0
    IL_003a:  ldind.i4
    IL_003b:  pop
    IL_003c:  br.s       IL_004a

    IL_003e:  ldc.i4.0
    IL_003f:  stloc      V_0
    IL_0043:  ldloca     V_0
    IL_0047:  ldind.i4
    IL_0048:  br.s       IL_003b

    IL_004a:  nop
    IL_004b:  nop
    IL_004c:  ldc.i4     0x1
    IL_0051:  stloc      V_0
    IL_0055:  ldloca     V_0
    IL_0059:  ldind.i4
    IL_005a:  br.s       IL_0068

    IL_005c:  ldc.i4.0
    IL_005d:  stloc      V_0
    IL_0061:  ldloca     V_0
    IL_0065:  ldind.i4
    IL_0066:  br.s       IL_0068

    IL_0068:  brfalse.s  IL_006a

    IL_006a:  ldc.i4.0
    IL_006b:  stloc      V_0
    IL_006f:  ldloca     V_0
    IL_0073:  ldind.i4
    IL_0074:  brfalse    IL_0079

    IL_0079:  ldsfld     class [mscorlib]System.Globalization.CultureInfo CrackMe.Properties.Resources::eval_b
    IL_007e:  ret
  } // end of method Resources::eval_a

  .method assembly hidebysig specialname static 
          void  eval_a(class [mscorlib]System.Globalization.CultureInfo A_0) cil managed
  {
    // Размер кода:       128 (0x80)
    .maxstack  2
    .locals init (int32 V_0)
    IL_0000:  ldc.i4     0x81f
    IL_0005:  stloc      V_0
    IL_0009:  ldloca     V_0
    IL_000d:  ldind.i4
    IL_000e:  ldc.i4     0x81f
    IL_0013:  stloc      V_0
    IL_0017:  ldloca     V_0
    IL_001b:  ldind.i4
    IL_001c:  ceq
    IL_001e:  switch     ( 
                          IL_002f,
                          IL_004c,
                          IL_002f)
    IL_002f:  br.s       IL_003e

    IL_0031:  ldc.i4.0
    IL_0032:  stloc      V_0
    IL_0036:  ldloca     V_0
    IL_003a:  ldind.i4
    IL_003b:  pop
    IL_003c:  br.s       IL_004a

    IL_003e:  ldc.i4.0
    IL_003f:  stloc      V_0
    IL_0043:  ldloca     V_0
    IL_0047:  ldind.i4
    IL_0048:  br.s       IL_003b

    IL_004a:  nop
    IL_004b:  nop
    IL_004c:  ldc.i4     0x1
    IL_0051:  stloc      V_0
    IL_0055:  ldloca     V_0
    IL_0059:  ldind.i4
    IL_005a:  br.s       IL_0068

    IL_005c:  ldc.i4.0
    IL_005d:  stloc      V_0
    IL_0061:  ldloca     V_0
    IL_0065:  ldind.i4
    IL_0066:  br.s       IL_0068

    IL_0068:  brfalse.s  IL_006a

    IL_006a:  ldc.i4.0
    IL_006b:  stloc      V_0
    IL_006f:  ldloca     V_0
    IL_0073:  ldind.i4
    IL_0074:  brfalse    IL_0079

    IL_0079:  ldarg.0
    IL_007a:  stsfld     class [mscorlib]System.Globalization.CultureInfo CrackMe.Properties.Resources::eval_b
    IL_007f:  ret
  } // end of method Resources::eval_a

  .property class [mscorlib]System.Resources.ResourceManager
          ResourceManager()
  {
    .custom instance void [System]System.ComponentModel.EditorBrowsableAttribute::.ctor(valuetype [System]System.ComponentModel.EditorBrowsableState) = ( 01 00 02 00 00 00 00 00 ) 
    .get class [mscorlib]System.Resources.ResourceManager CrackMe.Properties.Resources::eval_b()
  } // end of property Resources::ResourceManager
  .property class [mscorlib]System.Globalization.CultureInfo
          Culture()
  {
    .custom instance void [System]System.ComponentModel.EditorBrowsableAttribute::.ctor(valuetype [System]System.ComponentModel.EditorBrowsableState) = ( 01 00 02 00 00 00 00 00 ) 
    .get class [mscorlib]System.Globalization.CultureInfo CrackMe.Properties.Resources::eval_a()
    .set void CrackMe.Properties.Resources::eval_a(class [mscorlib]System.Globalization.CultureInfo)
  } // end of property Resources::Culture
} // end of class CrackMe.Properties.Resources

.class private auto ansi sealed beforefieldinit CrackMe.Properties.Settings
       extends [System]System.Configuration.ApplicationSettingsBase
{
  .custom instance void [System]System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(string,
                                                                                      string) = ( 01 00 4B 4D 69 63 72 6F 73 6F 66 74 2E 56 69 73   // ..KMicrosoft.Vis
                                                                                                  75 61 6C 53 74 75 64 69 6F 2E 45 64 69 74 6F 72   // ualStudio.Editor
                                                                                                  73 2E 53 65 74 74 69 6E 67 73 44 65 73 69 67 6E   // s.SettingsDesign
                                                                                                  65 72 2E 53 65 74 74 69 6E 67 73 53 69 6E 67 6C   // er.SettingsSingl
                                                                                                  65 46 69 6C 65 47 65 6E 65 72 61 74 6F 72 08 31   // eFileGenerator.1
                                                                                                  31 2E 30 2E 30 2E 30 00 00 )                      // 1.0.0.0..
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private static class CrackMe.Properties.Settings eval_a
  .field private notserialized string eval_b = uint8(0x20)
  .method public hidebysig specialname static 
          class CrackMe.Properties.Settings 
          eval_a() cil managed
  {
    // Размер кода:       127 (0x7f)
    .maxstack  2
    .locals init (int32 V_0)
    IL_0000:  ldc.i4     0xffffdc28
    IL_0005:  stloc      V_0
    IL_0009:  ldloca     V_0
    IL_000d:  ldind.i4
    IL_000e:  ldc.i4     0xffffdc28
    IL_0013:  stloc      V_0
    IL_0017:  ldloca     V_0
    IL_001b:  ldind.i4
    IL_001c:  ceq
    IL_001e:  switch     ( 
                          IL_002f,
                          IL_004c,
                          IL_002f)
    IL_002f:  br.s       IL_003e

    IL_0031:  ldc.i4.0
    IL_0032:  stloc      V_0
    IL_0036:  ldloca     V_0
    IL_003a:  ldind.i4
    IL_003b:  pop
    IL_003c:  br.s       IL_004a

    IL_003e:  ldc.i4.0
    IL_003f:  stloc      V_0
    IL_0043:  ldloca     V_0
    IL_0047:  ldind.i4
    IL_0048:  br.s       IL_003b

    IL_004a:  nop
    IL_004b:  nop
    IL_004c:  ldc.i4     0x1
    IL_0051:  stloc      V_0
    IL_0055:  ldloca     V_0
    IL_0059:  ldind.i4
    IL_005a:  br.s       IL_0068

    IL_005c:  ldc.i4.0
    IL_005d:  stloc      V_0
    IL_0061:  ldloca     V_0
    IL_0065:  ldind.i4
    IL_0066:  br.s       IL_0068

    IL_0068:  brfalse.s  IL_006a

    IL_006a:  ldc.i4.0
    IL_006b:  stloc      V_0
    IL_006f:  ldloca     V_0
    IL_0073:  ldind.i4
    IL_0074:  brfalse    IL_0079

    IL_0079:  ldsfld     class CrackMe.Properties.Settings CrackMe.Properties.Settings::eval_a
    IL_007e:  ret
  } // end of method Settings::eval_a

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       7 (0x7)
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System]System.Configuration.ApplicationSettingsBase::.ctor()
    IL_0006:  ret
  } // end of method Settings::.ctor

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Размер кода:       142 (0x8e)
    .maxstack  2
    .locals init (int32 V_0)
    IL_0000:  ldc.i4     0xffffce43
    IL_0005:  stloc      V_0
    IL_0009:  ldloca     V_0
    IL_000d:  ldind.i4
    IL_000e:  ldc.i4     0xffffce43
    IL_0013:  stloc      V_0
    IL_0017:  ldloca     V_0
    IL_001b:  ldind.i4
    IL_001c:  ceq
    IL_001e:  switch     ( 
                          IL_002f,
                          IL_004c,
                          IL_002f)
    IL_002f:  br.s       IL_003e

    IL_0031:  ldc.i4.0
    IL_0032:  stloc      V_0
    IL_0036:  ldloca     V_0
    IL_003a:  ldind.i4
    IL_003b:  pop
    IL_003c:  br.s       IL_004a

    IL_003e:  ldc.i4.0
    IL_003f:  stloc      V_0
    IL_0043:  ldloca     V_0
    IL_0047:  ldind.i4
    IL_0048:  br.s       IL_003b

    IL_004a:  nop
    IL_004b:  nop
    IL_004c:  ldc.i4     0x1
    IL_0051:  stloc      V_0
    IL_0055:  ldloca     V_0
    IL_0059:  ldind.i4
    IL_005a:  br.s       IL_0068

    IL_005c:  ldc.i4.0
    IL_005d:  stloc      V_0
    IL_0061:  ldloca     V_0
    IL_0065:  ldind.i4
    IL_0066:  br.s       IL_0068

    IL_0068:  brfalse.s  IL_006a

    IL_006a:  ldc.i4.0
    IL_006b:  stloc      V_0
    IL_006f:  ldloca     V_0
    IL_0073:  ldind.i4
    IL_0074:  brfalse    IL_0079

    IL_0079:  newobj     instance void CrackMe.Properties.Settings::.ctor()
    IL_007e:  call       class [System]System.Configuration.SettingsBase [System]System.Configuration.SettingsBase::Synchronized(class [System]System.Configuration.SettingsBase)
    IL_0083:  castclass  CrackMe.Properties.Settings
    IL_0088:  stsfld     class CrackMe.Properties.Settings CrackMe.Properties.Settings::eval_a
    IL_008d:  ret
  } // end of method Settings::.cctor

  .property class CrackMe.Properties.Settings
          Default()
  {
    .get class CrackMe.Properties.Settings CrackMe.Properties.Settings::eval_a()
  } // end of property Settings::Default
} // end of class CrackMe.Properties.Settings


// =============================================================

// *********** ДИЗАССЕМБЛИРОВАНИЕ ЗАВЕРШЕНО ***********************
// ВНИМАНИЕ: создан файл ресурсов Win32 d:\Projects\EPAM\Mentoring\Debugging\Project\ConsoleApplication1\HomeWorkCrackMe\OriginalExe\CrackMe.res
