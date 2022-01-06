<template>
  <div class="review m-2 bg-primary text-light p-5 rounded">
    <p class="text-start">
      <em
        >"{{ review.body }}" <i class="mdi mdi-star text-info"></i
        >{{ review.rating }}</em
      >
    </p>
    <p class="text-end m-0 action">
      <b @click="goToProfile"> - {{ review.creator.name }}</b>
    </p>
  </div>
</template>

  
<script>
import { Modal } from 'bootstrap'
import { useRouter } from 'vue-router'
export default {
  props: {
    review: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const router = useRouter()
    return {
      goToProfile() {
        Modal.getOrCreateInstance(document.getElementById('restaurant-modal')).hide()
        router.push({ name: 'Profile', params: { id: props.review.creatorId } })
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.action:hover {
  color: #6f6bc1;
}
</style>