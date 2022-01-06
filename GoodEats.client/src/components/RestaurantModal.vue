<template>
  <Modal id="restaurant-modal" size="modal-xl">
    <!-- the # identifies which slot to inject this code into -->
    <template #modal-body>
      <div class="container-fluid">
        <div class="text-end">
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <div class="row">
          <div class="col-6">
            <img
              height="500"
              class="w-100 object-fit-cover"
              :src="restaurant.picture"
              alt=""
            />
          </div>
          <div
            class="col-6 text-center d-flex flex-column justify-content-center"
          >
            <div class="info">
              <h2>
                {{ restaurant.name }} <i class="mdi mdi-star text-info"></i
                >{{
                  restaurant.averageRating > 0
                    ? restaurant.averageRating
                    : "N/A"
                }}
              </h2>
              <h4>{{ restaurant.category }}</h4>
              <p>
                <em>{{ restaurant.address }}</em>
              </p>
            </div>
            <!-- FIXME So ugly its mother wouldn't love it -->
            <form class="form collapse mb-5" @submit.prevent="createReview">
              <div
                class="
                  create-review
                  border border-secondary
                  p-3
                  m-2
                  d-flex
                  justify-content-between
                "
              >
                <div class="mb-3 text-start">
                  <label for="review" class="form-label">Review</label>
                  <textarea
                    rows="4"
                    cols="50"
                    name="review"
                    id="review"
                    placeholder="Write your Review...."
                    aria-describedby="review input"
                  />
                </div>
                <div class="mb-3 text-start">
                  <label for="rating" class="form-label">Rating</label>
                  <div>
                    <select name="rating" id="rating">
                      <option>1</option>
                      <option>2</option>
                      <option>3</option>
                      <option>4</option>
                      <option>5</option>
                    </select>
                  </div>
                </div>
              </div>
              <div class="text-end">
                <button class="btn btn-warning" type="submit">Create</button>
              </div>
            </form>
            <div class="reviews p-3 scroll" v-if="reviews.length">
              <div v-for="r in reviews" :key="r.id">
                <Review :review="r" />
              </div>
            </div>
            <div v-else>
              <p class="text-primary lighten-10 f-18">
                <em>No Reviews Yet</em>
              </p>
            </div>
          </div>
        </div>
      </div>
    </template>
  </Modal>
</template>


<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
export default {
  setup() {
    return {
      restaurant: computed(() => AppState.activeRestaurant),
      reviews: computed(() => AppState.reviews),
      createReview() {

      }
    }
  }
}
</script>


<style lang="scss" scoped>
.reviews {
  max-height: 400px;
  overflow-y: scroll;
}

.scroll::-webkit-scrollbar-track {
  background-color: transparent;
}

.scroll::-webkit-scrollbar {
  width: 5px;
  background-color: transparent;
}

.scroll::-webkit-scrollbar-thumb {
  background-color: var(--bs-info);
  border-radius: 5px;
}
</style>