// <auto-generated/>
using System;

namespace Telegram.Api.TL.Methods.Messages
{
	/// <summary>
	/// RCP method messages.setBotPrecheckoutResults.
	/// Returns <see cref="Telegram.Api.TL.TLBool"/>
	/// </summary>
	public partial class TLMessagesSetBotPrecheckoutResults : TLObject
	{
		[Flags]
		public enum Flag : Int32
		{
			Success = (1 << 1),
			Error = (1 << 0),
		}

		public bool IsSuccess { get { return Flags.HasFlag(Flag.Success); } set { Flags = value ? (Flags | Flag.Success) : (Flags & ~Flag.Success); } }
		public bool HasError { get { return Flags.HasFlag(Flag.Error); } set { Flags = value ? (Flags | Flag.Error) : (Flags & ~Flag.Error); } }

		public Flag Flags { get; set; }
		public Int64 QueryId { get; set; }
		public String Error { get; set; }

		public TLMessagesSetBotPrecheckoutResults() { }
		public TLMessagesSetBotPrecheckoutResults(TLBinaryReader from)
		{
			Read(from);
		}

		public override TLType TypeId { get { return TLType.MessagesSetBotPrecheckoutResults; } }

		public override void Read(TLBinaryReader from)
		{
			Flags = (Flag)from.ReadInt32();
			QueryId = from.ReadInt64();
			if (HasError) Error = from.ReadString();
		}

		public override void Write(TLBinaryWriter to)
		{
			UpdateFlags();

			to.Write(0x9C2DD95);
			to.Write((Int32)Flags);
			to.Write(QueryId);
			if (HasError) to.Write(Error);
		}

		private void UpdateFlags()
		{
			HasError = Error != null;
		}
	}
}