<template>
  <div
    class="restaurant p-3"
    :title="restaurant.name"
    data-bs-toggle="modal"
    data-bs-target="#restaurant-modal"
    @click="setActive"
  >
    <div class="bg-light elevation-1 rounded selectable">
      <img
        class="object-fit-cover w-100 rounded-top"
        height="200"
        :src="restaurant.picture"
        :alt="restaurant.name"
      />
      <div class="d-flex p-3 justify-content-between">
        <p class="m-0">
          <b>{{ restaurant.name }}</b>
        </p>
        <p class="m-0" v-if="restaurant.averageRating != 0">
          <i class="mdi mdi-star text-warning"></i>
          {{ restaurant.averageRating.toFixed(1) }}
        </p>
        <p class="m-0" v-else>N/A</p>
      </div>
    </div>
  </div>
</template>


<script>
import { Modal } from 'bootstrap'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { AppState } from '../AppState'
import { reviewsService } from '../services/ReviewsService'
export default {
  props: {
    restaurant: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      async setActive() {
        try {
          AppState.activeRestaurant = props.restaurant
          await reviewsService.getByRestaurantId(props.restaurant.id)
        } catch (error) {
          // something failed, log it and close the modal
          logger.error(error)
          Modal.getOrCreateInstance(document.getElementById("restaurant-modal")).hide()
          Pop.toast(error, 'error', 'center')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.restaurant:hover {
  transform: scale(1.02);
}

.restaurant {
  transition: 0.2s all ease;
}
</style>