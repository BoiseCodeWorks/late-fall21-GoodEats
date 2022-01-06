<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col p-0">
        <img
          class="w-100 object-fit-cover"
          height="500"
          src="https://images.unsplash.com/photo-1414235077428-338989a2e8c0?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80"
          alt="hero image"
        />
      </div>
    </div>
    <div class="row mt-2">
      <div class="col-3" v-for="r in restaurants" :key="r.id">
        <Restaurant :restaurant="r" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { logger } from '../utils/Logger'
import { restaurantsService } from '../services/RestaurantsService'
import Pop from '../utils/Pop'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  setup() {
    onMounted(async () => {
      try {
        await restaurantsService.getAll()
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    })

    return {
      restaurants: computed(() => AppState.restaurants)
    }
  }
}
</script>

<style scoped lang="scss">
</style>
