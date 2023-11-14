<template>
    <!-- <div class="calendar-navigator">
        <IconButton @click="() => changeMonth(false)" :style="style.navBar.calendarNavigationButton" :icon="Icons.LeftArrow" />
        <IconButton @click="() => changeMonth(true)" :style="style.navBar.calendarNavigationButton" :icon="Icons.RightArrow" />
        <span class="calendar-navigator-label">{{ monthAndYear }}</span>
    </div> -->
</template>


<script setup lang="ts">
// import { Icons } from '../../models/icons/Icons';
// import IconButton from '../reusable/IconButton.vue';
// import store from '../../store/store';
// import { computed } from '@vue/reactivity';

// const style = computed(() => {
//     return store.actions.getSectionStyles()
// })

// const monthAndYear = computed(() => {
//     const date = store.state.calendarState.selectedDate

//     return `${date.getMonthAsString()}, ${date.getYearAsString()}`
// })

// const changeMonth = (increment: boolean) => {
//     if (increment) {
//         store.actions.incrementMonth()
//     } else {
//         store.actions.decrementMonth()
//     }
// }
</script>

<style scoped>
.calendar-navigator {
    display: flex;
    align-items: center;
}

.calendar-navigator-label {
    padding-left: 10px;
}
</style>