﻿using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ADOX
{
	// Token: 0x02000D21 RID: 3361
	[DefaultMember("Item"), CompilerGenerated, Guid("0000061D-0000-0010-8000-00AA006D2EA4"), TypeIdentifier]
	[ComImport]
	public interface Columns : IEnumerable, _Collection
	{
		// Token: 0x06007359 RID: 29529
		void _VtblGap1_4();

		// Token: 0x0600735A RID: 29530
		[DispId(1610809345)]
		void Append([MarshalAs(UnmanagedType.Struct)] [In] object Item, [In] DataTypeEnum Type = DataTypeEnum.adVarWChar, [In] int DefinedSize = 0);
	}
}
