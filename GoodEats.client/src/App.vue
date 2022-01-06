<template>
  <header class="fixed-top">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <RestaurantModal />
  <footer>
    <div class="bg-dark text-light text-center p-4">
      Made with 💖 by CodeWorks™
    </div>
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
</style>
