using Spine;
using Spine.Unity;

namespace Game.Animals
{
    public class CowAnimationHandler : IAnimalAnimationHandler
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
            this.animation.Skeleton.FindSlot("img/Tail").Attachment = null;
        }

        public void PlayAnimation(string name, bool isLoop = false)
        {
            animation.loop = isLoop;
            animation.AnimationName = name;
        }

        public void PlayAnimation(int id, bool isLoop = false)
        {
            animation.loop = isLoop;
        }
        

        public void PlayIdleAnimation()
        {
            animation.loop = true;
            animation.AnimationName = "Idle";
        }

        public void PlaySadAnimation()
        {
            animation.loop = true;
            animation.AnimationName = "Sad";
        }

        public void PlayHappyAnimation()
        {
            animation.loop = false;
            animation.AnimationName = "Idle";
        }

        public void SetTailAttachment(Attachment attachment)
        {
            animation.Skeleton.FindSlot("img/Tail").Attachment = attachment;
            animation.Skeleton.UpdateCache();
        }


        public Attachment GetTailAttachment(SkeletonData skeletonData)
        {
            SlotData slot = skeletonData.FindSlot("img/Tail");
            return skeletonData.FindSkin("default").GetAttachment(slot.Index, "img/Tail");
        }
    }
}