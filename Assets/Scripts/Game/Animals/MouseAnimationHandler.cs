using Spine;
using Spine.Unity;

namespace Game.Animals
{
    public class MouseAnimationHandler : IAnimalAnimationHandler
    {
        private SkeletonAnimation animation;
        private SkeletonDataAsset skeletonAnimationSkeletonDataAsset;

        public void SetUpAnimation(SkeletonAnimation animation, SkeletonDataAsset skeletonDataAsset)
        {
            this.animation = animation;
            skeletonAnimationSkeletonDataAsset = skeletonDataAsset;
            
            this.animation.skeletonDataAsset = skeletonAnimationSkeletonDataAsset;
            this.animation.initialSkinName = "default";
            this.animation.Initialize(true);
        }


        public void PlayAnimation(string name, bool isLoop = false)
        {
        }
    
    
        public void PlayAnimation(int id, bool isLoop = false)
        {
        
        }

        public void PlayIdleAnimation()
        {
            animation.loop = true;
            animation.AnimationName = "Idle";
        }

        public void PlaySadAnimation()
        {
            animation.loop = true;
            animation.AnimationName = "sad";
        }

        public void PlayHappyAnimation()
        {
            animation.loop = true;
            animation.AnimationName = "Dance";
        }

        public void SetTailAttachment(Attachment attachment) => animation.Skeleton.FindSlot("Tail").Attachment = attachment;


        public Attachment GetTailAttachment(SkeletonData skeletonData)
        {
            SlotData slot = skeletonData.FindSlot("Tail");
            return skeletonData.FindSkin("default").GetAttachment(slot.Index, "Tail");
        }
    }
}