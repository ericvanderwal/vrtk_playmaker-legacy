// Custom Action by DumbGameDev

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Set simple pointer settings.")]

	public class  SetSimplePointerSettings : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_SimplePointer))]    

		public FsmOwnerDefault gameObject;

		[TitleAttribute("Pointer Thickness")]
		public FsmFloat PointerThickness;

		[TitleAttribute("Pointer Length")]
		public FsmFloat PointerLength;

		[TitleAttribute("Show Pointer Tip")]
		public FsmBool PointerTip;

		public FsmBool everyFrame;

		VRTK.VRTK_SimplePointer theScript;

		public override void Reset()
		{

			gameObject = null;
			PointerTip = true;
			PointerThickness = null;
			PointerThickness = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_SimplePointer>();

			if (!everyFrame.Value)
			{
				MakeItSo();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}


		void MakeItSo()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			theScript.showPointerTip = PointerTip.Value;
			theScript.pointerThickness = PointerThickness.Value;
			theScript.pointerLength = PointerLength.Value;

		}

	}
}
