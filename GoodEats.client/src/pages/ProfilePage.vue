<template>
  <div class="profile">
    <h1>Welcome to the profile page</h1>

    {{ reviews }}
  </div>
</template>


<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { onMounted } from '@vue/runtime-core'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { reviewsService } from '../services/ReviewsService'
export default {
  setup() {
    const route = useRoute()
    onMounted(async () => {
      try {
        await reviewsService.getByCreatorId(route.params.id)
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    })
    return {
      reviews: computed(() => AppState.profileReviews)
    }
  }
}
</script>


<style lang="scss" scoped>
</style>