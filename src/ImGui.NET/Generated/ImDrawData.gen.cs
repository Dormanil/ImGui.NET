using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe struct ImDrawData
    {
        public byte Valid;
        public ImDrawList** CmdLists;
        public int CmdListsCount;
        public int TotalIdxCount;
        public int TotalVtxCount;
        public Vector2 DisplayPos;
        public Vector2 DisplaySize;
    }
    public unsafe struct ImDrawDataPtr
    {
        public ImDrawData* NativePtr { get; }
        public ImDrawDataPtr(ImDrawData* nativePtr) => NativePtr = nativePtr;
        public static implicit operator ImDrawDataPtr(ImDrawData* nativePtr) => new ImDrawDataPtr(nativePtr);
        public static implicit operator ImDrawData* (ImDrawDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        public ref byte Valid => ref Unsafe.AsRef<byte>(&NativePtr->Valid);
        public ImDrawList** CmdLists { get => NativePtr->CmdLists; set => NativePtr->CmdLists = value; }
        public ref int CmdListsCount => ref Unsafe.AsRef<int>(&NativePtr->CmdListsCount);
        public ref int TotalIdxCount => ref Unsafe.AsRef<int>(&NativePtr->TotalIdxCount);
        public ref int TotalVtxCount => ref Unsafe.AsRef<int>(&NativePtr->TotalVtxCount);
        public ref Vector2 DisplayPos => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplayPos);
        public ref Vector2 DisplaySize => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplaySize);
        public void ScaleClipRects(Vector2 sc)
        {
            ImGuiNative.ImDrawData_ScaleClipRects(NativePtr, sc);
        }
        public void DeIndexAllBuffers()
        {
            ImGuiNative.ImDrawData_DeIndexAllBuffers(NativePtr);
        }
        public void Clear()
        {
            ImGuiNative.ImDrawData_Clear(NativePtr);
        }
    }
}
