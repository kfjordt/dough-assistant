<template>
    <div class="calendar-navigator">
        <IconButton @click="() => changeMonth(false)" :elementStyle="InteractableElementLight" :icon="Icons.LeftArrow" />
        <IconButton @click="() => changeMonth(true)" :elementStyle="InteractableElementLight" :icon="Icons.RightArrow" />
        <span class="calendar-navigator-label">{{ monthAndYear }}</span>
    </div>
</template>


<script setup lang="ts">
import { Icons } from '../../models/icons/Icons';
import { InteractableElementLight } from '../../models/style/Styles';
import IconButton from '../reusable/IconButton.vue';
import store from '../../store/store';
import { computed } from '@vue/reactivity';

const monthAndYear = computed(() => {
    const date = store.state.calendarState.selectedDate

    return `${date.getMonthAsString()}, ${date.getYearAsString()}`
})

const changeMonth = (increment: boolean) => {
    if (increment) {
        store.actions.incrementMonth()
    } else {
        store.actions.decrementMonth()
    }
}
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