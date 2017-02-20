// Custom Action by DumbGameDev

	using UnityEngine;

	namespace HutongGames.PlayMaker.Actions
	{
		[ActionCategory("VRTK")]
		[Tooltip("Set simple pointer material colors.")]

		public class  SetSimplePointerMaterial : FsmStateAction
		{
			[RequiredField]
			[CheckForComponent(typeof(VRTK.VRTK_SimplePointer))]    

			public FsmOwnerDefault gameObject;

			[Tooltip("Set pointer material.")]
			[TitleAttribute("Pointer Material")]
			public FsmMaterial lazerMaterial;

			public FsmBool everyFrame;

			VRTK.VRTK_SimplePointer theScript;

			public override void Reset()
			{

				gameObject = null;
				lazerMaterial = null;
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

			theScript.pointerMaterial = lazerMaterial.Value;

			}

		}
	}




